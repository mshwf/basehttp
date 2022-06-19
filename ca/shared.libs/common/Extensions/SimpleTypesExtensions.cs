using System;
using System.Text;

namespace GET.PKI.Common
{
    public static class SimpleTypesExtensions
    {
        #region String
        public static bool NotEmpty(this string str) => !string.IsNullOrWhiteSpace(str);
        public static bool IsEmptyJSON(this string str) => (str == "{}" || str == "{[]}" || str == "{ }");
        public static byte[] ToByteArrayASCII(this string str) => Encoding.ASCII.GetBytes(str);
        public static byte[] ToByteArrayUTF(this string str) => new UTF8Encoding(true, true).GetBytes(str);
        #endregion

        #region Guid
        public static bool IsValidGuid(this Guid guid) => !guid.Equals(Guid.Empty);
        public static bool IsValidGuid(this Guid? guid) => guid.HasValue && !guid.IsValidGuid();
        #endregion
    }
}
