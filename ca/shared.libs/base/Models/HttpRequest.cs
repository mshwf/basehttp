using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GET.PKI.Base
{
    public class HttpRequest
    {
        public HttpRequest(string url, List<KeyValuePair<string, string>> headers)
        {
            Headers = headers;
            Url = url;
        }

        public string Method { get; set; }
        public string Url { get; set; }
        public List<KeyValuePair<string, string>> Headers { get; set; }
    }


    public class HttpGetRequest : HttpRequest
    {
        public HttpGetRequest(string url, object querryParameters, List<KeyValuePair<string, string>> headers)
        : base(url, headers)
        {
            Method = "Get";
            QueryString = Serialization.ObjectToKeyValueString(querryParameters);
        }
        public string QueryString { get; set; }
    }


    public class HttpPostRequest : HttpRequest
    {
        public HttpPostRequest(string url, object body, ContentType? contentType, List<KeyValuePair<string, string>> headers)
            : base(url, headers)
        {
            ContentType = contentType == null ? Base.ContentType.Json.ToDescriptionString() : contentType.ToDescriptionString();
            Headers = headers;
            Method = "Post";

            switch (contentType)
            {
                case Base.ContentType.Json:
                    // default ContentType is Json
                    Body = Serialization.ObjectToJsonString(body);
                    break;
                case Base.ContentType.Form:
                    // if form encoded
                    // query string format in GET is similar to Forms variables in POST
                    Body = Serialization.ObjectToKeyValueString(body);
                    break;
                default:
                    Body = Serialization.ObjectToJsonString(body);
                    break;
            }
        }

        public string Body { get; }
        public string ContentType { get; }
    }

    public class HttpDeleteRequest : HttpRequest
    {
        public HttpDeleteRequest(string url, object querryParameters, List<KeyValuePair<string, string>> headers)
        : base(url, headers)
        {
            Method = "Delete";
            QueryString = Serialization.ObjectToKeyValueString(querryParameters);
        }
        public string QueryString { get; set; }
    }

}