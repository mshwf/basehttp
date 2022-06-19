using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GET.PKI.Common
{
    public class X509Utilities
    {
        /// <summary>
        /// Create CRL Distribution Points (CDP) Extension to add to the CertificateExtensions collection
        /// </summary>
        /// <param name="url">CRL endpoint URL. URL Length must not exceed 119 characters.</param>
        /// <returns>CRL distribution points extension.</returns>
        public static X509Extension MakeCdp(string url, bool critical)
        {
            byte[] encodedUrl = Encoding.ASCII.GetBytes(url);

            if (encodedUrl.Length > 119)
            {
                throw new NotSupportedException();
            }

            byte[] payload = new byte[encodedUrl.Length + 10];
            int offset = 0;
            payload[offset++] = 0x30;
            payload[offset++] = (byte)(encodedUrl.Length + 8);
            payload[offset++] = 0x30;
            payload[offset++] = (byte)(encodedUrl.Length + 6);
            payload[offset++] = 0xA0;
            payload[offset++] = (byte)(encodedUrl.Length + 4);
            payload[offset++] = 0xA0;
            payload[offset++] = (byte)(encodedUrl.Length + 2);
            payload[offset++] = 0x86;
            payload[offset++] = (byte)(encodedUrl.Length);
            Buffer.BlockCopy(encodedUrl, 0, payload, offset, encodedUrl.Length);

            return new X509Extension("2.5.29.31", payload, critical: critical);
        }
    }
}
