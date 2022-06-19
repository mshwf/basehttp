using System;
using System.IO;
using System.Net;

namespace GET.PKI.Common.Utilities
{
    public class HTTPRequest
    {
        public static string BuildRequest(string url, HTTPMethods method, string contentType,
            string postData, WebHeaderCollection headers)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.KeepAlive = false;
                req.ProtocolVersion = HttpVersion.Version10;
                req.Method = method.ToString();
                req.Timeout = 20000;
                //req.AllowWriteStreamBuffering = false;

                if (method == HTTPMethods.POST)
                {
                    req.ContentType = contentType;
                    byte[] postBytes = System.Text.Encoding.ASCII.GetBytes(postData);
                    if (headers != null)
                    {
                        for (int i = 0; i < headers.Count; ++i)
                        {
                            string header = headers.GetKey(i);
                            foreach (string value in headers.GetValues(i))
                                req.Headers.Add(header, value);
                        }
                    }
                    if (postBytes.Length != 0)
                        req.ContentLength = postBytes.Length;

                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream resStream = response.GetResponseStream();
                var sr = new StreamReader(response.GetResponseStream());
                string responseText = sr.ReadToEnd();
                return responseText;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public enum HTTPMethods
    {
        GET,
        POST
    }
}
