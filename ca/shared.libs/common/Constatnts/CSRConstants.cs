using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace GET.PKI.Common
{
    public static class CSRConstants
    {
        public static readonly Dictionary<string, X509KeyUsageFlags> KeyUsage = new Dictionary<string, X509KeyUsageFlags>
        {
            {"Digital Signature", X509KeyUsageFlags.DigitalSignature },
            {"Non Repudiation", X509KeyUsageFlags.NonRepudiation },
            {"Key Encipherment", X509KeyUsageFlags.KeyEncipherment },
            {"Data Encipherment", X509KeyUsageFlags.DataEncipherment },
            {"Key Agreement", X509KeyUsageFlags.KeyAgreement },
            {"Key Cert Sign", X509KeyUsageFlags.KeyCertSign },
            {"CRL Sign", X509KeyUsageFlags.CrlSign },
            {"Encipher Only", X509KeyUsageFlags.EncipherOnly },
            {"Decipher Only", X509KeyUsageFlags.DecipherOnly },
        };
        public static readonly List<Oid> EnhancedKeyUsages = new List<Oid>
        {
             new Oid("1.2.840.113583.1.1.5", "Adobe Certified Document Signing"),
             new Oid("2.5.29.37.0", "Any Purpose"),
             new Oid("1.3.6.1.5.5.7.3.2", "Client Authentication"),
             new Oid("1.3.6.1.5.5.7.3.3", "Code Signing"),
             new Oid("1.3.6.1.5.5.7.3.4", "Email Protection"),
             new Oid("1.3.6.1.5.5.7.3.5", "IPSEC End System"),
             new Oid("1.3.6.1.5.5.7.3.6", "IPSEC Tunnel"),
             new Oid("1.3.6.1.5.5.7.3.7", "IPSEC User"),
             new Oid("1.3.6.1.4.1.311.2.1.22", "Microsoft Commercial Code Signing"),
             new Oid("1.3.6.1.4.1.311.2.1.21", "Microsoft Individual Code Signing"),
             new Oid("1.3.6.1.4.1.311.10.3.1", "Microsoft Trust List Signing"),
             new Oid("1.3.6.1.4.1.311.10.3.4", "Microsoft Encrypted File System"),
             new Oid("1.3.6.1.4.1.311.10.3.4.1", "Microsoft EFS File Recovery"),
             new Oid("1.3.6.1.4.1.311.10.3.3", "Microsoft Server Gated Crypto"),
             new Oid("1.3.6.1.4.1.311.20.2.2", "Microsoft Smart Card Logon"),
             new Oid("2.16.840.1.113730.4.1", "Netscape Server Gated Crypto"),
             new Oid("1.3.6.1.5.5.7.3.9", "OCSP Signing"),
             new Oid("1.3.6.1.5.5.7.3.1", "Server Authentication"),
             new Oid("1.3.6.1.5.5.7.3.8", "Timestamping")
        };

        public static Dictionary<string, string> EnhancedKeyUsageNames => EnhancedKeyUsages.ToDictionary(kOid => kOid.Value, vOid => vOid.FriendlyName);
        public static List<(string OidValue, string OidName)> EnhancedKeyUsagesTupple = EnhancedKeyUsages.Select(x => (x.Value, x.FriendlyName)).ToList();
    }
}
