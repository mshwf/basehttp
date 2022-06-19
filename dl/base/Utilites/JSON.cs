using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
//using System.Text.Json;

namespace GET.Spooler.Base
{
    public static class JSON
    {
        //static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        static JSON()
        {
            //jsonOptions = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                JToken.Parse(json);
                return JsonConvert.DeserializeObject<T>(json);//, jsonOptions
            }
            catch (JsonReaderException)
            {
                throw new Exception("String is not valid JSON.");
            }
            catch
            {
                throw;
            }

        }
        public static string Serialize(object obj) => JsonConvert.SerializeObject(obj);//, options: jsonOptions

    }
}
