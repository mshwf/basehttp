using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Collections;

namespace GET.Spooler.Base
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
            properties = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null)
                .Select(p => QueryConverter(obj, p));

            //properties = from p in obj.GetType().GetProperties()
            //             where p.GetValue(obj, null) != null
            //             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            keyValuePair = string.Join("&", properties.ToArray());
            return keyValuePair;
        }

        private static string QueryConverter(object obj, PropertyInfo p)
        {
            var pValue = p.GetValue(obj, null);
            if (pValue is IEnumerable && !(pValue is string))
                return IEnumerableToQueryString(pValue as IEnumerable, p.Name);

            return p.Name + "=" + HttpUtility.UrlEncode(pValue.ToString());
        }

        private static string IEnumerableToQueryString(IEnumerable list, string queryParameterName)
        {
            if (list is string) return list.ToString();
            if (list is null) return null;
            StringBuilder query = new StringBuilder();
            int i = 0;
            foreach (var item in list)
            {
                query.Append($"{queryParameterName}[{i}]={item}&");
                i++;
            }
            //handle i=0
            var finalQuery = query.ToString().Trim('&');
            return finalQuery;
        }

        internal static string ObjectToJsonString(object body)
        {
            return body == null ? "" : JSON.Serialize(body);
        }
        public static HttpContent ToStringContent(object obj)
        {
            if (obj == null) return null;
            var json = JSON.Serialize(obj);
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