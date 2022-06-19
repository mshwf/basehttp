using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace GET.PKI.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetOid(this HashAlgorithmName algorithmName)
        {
            switch (algorithmName.Name)
            {
                case "SHA512":
                    return "101";
                default:
                    return string.Empty;
            }
        }
    }
}
