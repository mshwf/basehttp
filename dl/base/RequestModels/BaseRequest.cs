using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GET.Spooler.Base
{
    public enum ContentType
    {
        [Description("application/json")]
        Json = 0,
        [Description("application/x-www-form-urlencoded")]
        Form = 1,
        [Description("multipart/form-data")]
        Multipart = 2

    }
    public class BaseRequest
    {
        //TODO: remove the controller, action and routeSegments; use the apiendpoint ✅
        protected BaseRequest(string route, ContentType? contentType, List<KeyValuePair<string, string>> headers = null)
        {
            Route = route;
            Headers = headers;
            ContentType = contentType;
        }

        public string Route { get; }
        public ContentType? ContentType { get; }
        public List<KeyValuePair<string, string>> Headers { get; }
    }

    public class BaseGetRequest : BaseRequest
    {
        //TODO: try to use params instead to object to get the query string as it more understood and readability "Later"
        public BaseGetRequest(string route, object queryParams = null, List<KeyValuePair<string, string>> headers = null)
    : base(route, null, headers)
        {
            QueryParams = queryParams;
        }

        public object QueryParams { get; set; }
    }
    public class BasePostRequest : BaseRequest
    {
        public BasePostRequest(string route, object body, List<KeyValuePair<string, string>> headers = null)
            : base(route, null, headers)
        {
            Body = body;
        }

        public object Body { get; }
    }

    public class BasePutRequest : BaseRequest
    {
        public BasePutRequest(string route, object body = null, object queryParams = null, List<KeyValuePair<string, string>> headers = null)
            : base(route, null, headers)
        {
            Body = body;
            QueryParams = queryParams;
        }

        public object Body { get; }
        public object QueryParams { get; set; }
    }
    public class BaseDeleteRequest : BaseRequest
    {
        public BaseDeleteRequest(string route, object queryParams = null, List<KeyValuePair<string, string>> headers = null)
            : base(route, null, headers)
        {
            QueryParams = queryParams;
        }
        public object QueryParams { get; set; }
    }
}