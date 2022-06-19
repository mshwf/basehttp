using GET.LicenseManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace GET.Spooler.Base
{
    public class LicenseStatusUtility
    {
        static Thread LicenseThread = null;
        static bool isFirstTimeToCheckLicense = true;
        static LicenseStatus status = LicenseStatus.LICENSE_NOT_EXISTS;
        static Semaphore sm = new Semaphore(0, 1);


        public static LicenseStatus CheckIfLicenseIsExists()
        {

#if DEBUG
            return LicenseStatus.Activated;
#else
            if (LicenseThread == null)
            {
                var thCurrent = Thread.CurrentThread;

                LicenseThread = new Thread(() =>
                {
                    while (true)
                    {



                        SpoolerLicenseHelper malawiLicenseHelper = new SpoolerLicenseHelper();
                        XElement features;
                        LicenseStatus isLicenseExists = SpoolerLicenseHelper.ValidateLicenseFile(out features);
                        status = isLicenseExists;


                        if (isFirstTimeToCheckLicense)
                        {
                            isFirstTimeToCheckLicense = false;
                            if (thCurrent.ThreadState == ThreadState.WaitSleepJoin)
                                thCurrent.Interrupt();
                        }

                        Thread.Sleep(6000 * 60 * 60);                       
                    }
                }
            );
                LicenseThread.Start();
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException ex)
                {
                    //Logger.Log(MethodBase.GetCurrentMethod().Name, ex);
                    //return error;

                }
            }

            return status;
#endif

        }
    }

    public class SpoolerLicenseHelper
    {
        private static string SDKModulePublicKey { get; } = @"<?xml version=""1.0"" encoding=""utf-16""?><RSAParameters xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Exponent>AQAB</Exponent><Modulus>t77vaAl9YGeHXn1ct6tT4nAfiTly+kAXltqM4mCDEablHRPIwhwIrymBz37K0vphOAWIjvrUZtxiWjL4u1GXsEVait1Z0uI3xjelX03uiM3Y7QaNnpL+EYcsVnwnYqbdGP3ahsDoOmEmoFQavXtgK5So4tRXJY2pzmtkiHoVIOpNSBO3d6myyJsVo9/5J8KLi0X15wMeZaj5N7SWk2XiQNEnpLhEbKrv5isd/jQQW6e+fX28PhasoeJPS1Euy75AGWZrtjUfoRC7RAeJpzWoV1HSmthlHEOe5E84Ply0Ra+lEsxehU3EzZ6frDAJyIWYM3ULAtjlfXYx+TO2sew8YJTUWmd2i5nBZ0AIS/sxcn3ml5vXaMdAHS06JZF49HLZjCXvfYLtncAruEhM2SfurfDPbRIuVAEN/sCQG4AtB2T14csYSSAIBdf2p0fQUN+jrsIEuGDH5lccE4SVwFuEHpsdC4v3LXRYAXixx08LLvZYBxoNh3xGvjxkr2JtYTg6AOYvpGzxuVB2FP/8GubA5kIdS3iu1F8Aem/Tj6Z7xoC23HvjYQ3hWrt+2gKlw8p/ZjuuNFUVPpxRiTsqsz+Hrc6sdDppziR1PlI24npSEKBw6Ak2gNPe41LhHvDQXYUrbCURzGcqodsXvxyKEe/tIagJ99HcF0zJwLW19/kXcmE=</Modulus></RSAParameters>";
        private static string SDKLicenseFilePath { get; } = "C:\\ProgramData\\GET\\GET Spooler System\\GET_Spooler_System.glcns";

        private static string SDKModuleName { get; } = "GET Spooler System";

        private static string SDKModuleCode { get; } = "GETSpoolerSystem";
        private static XElement SDKFeatures;
        private static string RegisterykeyName = @"SOFTWARE\GET Spooler System\Info";

        internal enum GETEncodingFeatures
        {
            [Description("735647f0-3471-43a9-890e-4982c6287b67")]
            Use_Spooler_System
        }

        private bool CheckProtectionByLicense()
        {
            bool result = false;
            
            //TODO: GET.LicenseManagement to be .net standard ✅
            var IsSDKLicenseFilePathExit = (LicenseStatus)GETLicenseManager.CheckProtectionByLicense(SDKLicenseFilePath);
            //var IsSDKLicenseFilePathExit = LicenseStatus.Activated;
            if (IsSDKLicenseFilePathExit == LicenseStatus.Activated)
                result = true;

            return result;
        }



        public static LicenseStatus ValidateLicenseFile(out XElement features)
        {
            string publicKey = SDKModulePublicKey;
            string moduleName = SDKModuleName;
            string RegistryName = RegisterykeyName;
            string moduleCode = SDKModuleCode;
            features = null;

            double RemainingDaysToExpire; string supportedFeatures = "";
            LicenseStatus result = LicenseStatus.Activated;
            byte[] licenseBytes = null;
            try
            {
                //string licenseFile = $"{ System.AppDomain.CurrentDomain.BaseDirectory}{moduleName}\\{moduleName.Replace(" ", "_")}.glcns";
                string licenseFile = SDKLicenseFilePath;
                if (File.Exists(licenseFile))
                {
                    string licenseStr = File.ReadAllText(licenseFile);

                    licenseBytes = Convert.FromBase64String(licenseStr);
                    //TODO: GET.LicenseManagement to be .net standard ✅
                    result = (LicenseStatus)GETLicenseManager.DecryptLicense(licenseFile, publicKey, moduleName, RegistryName,
                    moduleCode, out RemainingDaysToExpire, out supportedFeatures);

                    if (result == LicenseStatus.Activated) features = XElement.Parse(supportedFeatures);

                }
                else
                {
                    result = LicenseStatus.LICENSE_NOT_EXISTS;
                }
            }

            catch (Exception ex)
            {
                result = LicenseStatus.INVALID_LICENSE_FILE;
            }

            return result;
        }

    }


}
