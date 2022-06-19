using System.Collections.Generic;

namespace GET.PKI.Common
{
    public static class OidList
    {
        public const string RSAOid = "1.2.840.113549.1.1.1";

        public static List<(string Name, string Oid)> HashAlgorithms = new List<(string, string)>
        {
            ("SHA1","1.3.14.3.2.26"),
            ("SHA256","2.16.840.1.101.3.4.2.1"),
            ("SHA384","2.16.840.1.101.3.4.2.2"),
            ("SHA512","2.16.840.1.101.3.4.2.3"),
        };

        public static OidDictionary CMSContentTypesx = new OidDictionary
        {
            ["Data"] = "1.2.840.113549.1.7.1",
            ["MRTD Security LDS"] = "2.23.136.1.1.1",
            ["Digested Data"] = "1.2.840.113549.1.7.5",
            ["Encrypted Data"] = "1.2.840.113549.1.7.6",
            ["Enveloped Data"] = "1.2.840.113549.1.7.3"
        };

    }



}
