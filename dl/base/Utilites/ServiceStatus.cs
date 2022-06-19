using System.Diagnostics;
using System.Reflection;

namespace GET.Spooler.Base
{
    public static class ServiceStatusUtility
    {
        static string vnumber = null;
        public static string GetVersionNumber()
        {
            if (vnumber == null)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                vnumber = fvi.FileVersion;
            }
            return vnumber;
        }
    }
}