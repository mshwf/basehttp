using System;

namespace GET.Spooler.Base
{
    public class BaseException : Exception
    {
        public string ServiceName { get; }

        public BaseException(string message, string serviceName, Exception inner = null) : base(message, inner)
        {
            ServiceName = serviceName;
        }
        public BaseException() { }
    }
    public class NetworkException : BaseException
    {
        public NetworkException(string msg, string serviceName, Exception inner) : base(msg, serviceName, inner) { }
        public NetworkException(string msg, string serviceName) : base(msg, serviceName, null) { }

    }

    public class ResponseDeserializationException : BaseException
    {
        public string OriginalContent { get; }

        public ResponseDeserializationException(string msg, string originalContent, string serviceName, Exception inner)
            : base(msg, serviceName, inner)
        {
            OriginalContent = originalContent;
        }
    }
}