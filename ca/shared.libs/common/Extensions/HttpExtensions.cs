using Newtonsoft.Json;
using System.Net.Http;

namespace GET.PKI.Common
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Serializes the object then wraps it inside StringContent, for HTTP POST action, using UTF8 encoding and "application/json" media type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpContent ToStringContent(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return content;
        }
    }
}
