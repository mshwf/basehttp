using System;
using System.Security.Cryptography;

namespace GET.PKI.Common.Utilities
{
    public static class CryptoHelper
    {
        //These OIDs throw exception when initialized with Oid.FromOidvalue(..), this helper method handle the exception
        //1.2.840.113583.1.1.5, Adobe Certified Document Signing
        //1.3.6.1.4.1.311.2.1.22, Microsoft Commercial Code Signing
        //1.3.6.1.4.1.311.2.1.21, Microsoft Individual Code Signing
        //1.3.6.1.4.1.311.10.3.3, Microsoft Server Gated Crypto
        //2.16.840.1.113730.4.1, Netscape Server Gated Crypto
        public static bool TryGetOid(string oidValue, OidGroup oidGroup, out Oid oid)
        {
            try
            {
                oid = Oid.FromOidValue(oidValue, oidGroup);
                return true;
            }
            catch (CryptographicException)//The friendly name for the OID value was not found.
            {
                oid = null;
                return false;
            }
            
            catch (Exception)
            {
                oid = null;
                return false;
            }
        }
    }
}
