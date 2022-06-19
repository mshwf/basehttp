using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GET.PKI.Base
{
    class Serialization
    {
        /// <summary>
        /// Converts Object to query params where the key format depends on CaseStrategy 
        /// Used in GET:query or POST:forms
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToKeyValueString(object obj)
        {
            var keyValuePair = string.Empty;

            if (obj == null) return keyValuePair;

            IEnumerable<string> properties = null;
            properties = from p in obj.GetType().GetProperties()
                         where p.GetValue(obj, null) != null
                         select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            keyValuePair = string.Join("&", properties.ToArray());
            return keyValuePair;
        }

        internal static string ObjectToJsonString(object body)
        {
            return body == null ? "" : JsonConvert.SerializeObject(body);
        }
        public static HttpContent ToStringContent(object obj)
        {
            if (obj == null) return null;
            var json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        public static string ToRoutePath(params object[] parameters)
        {
            var p = "";
            if (parameters == null || parameters.Length == 0) return p;
            for (int i = 0; i < parameters.Length; i++)
                p += parameters[i].ToString() + "/";
            return p.Trim(' ', '/');
        }
    }
}