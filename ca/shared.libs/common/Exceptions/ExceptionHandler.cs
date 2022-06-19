using System;
using System.Net.Http;

namespace GET.PKI.Common
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex, string resourceUri = null)
        {
            //TODO: write to log
            //TODO: look for specific exception types and handle accordingly 
            //TODO: can you handle FE here?
            switch (ex)
            {
                case AggregateException ae:
                    foreach (var inner in ae.InnerExceptions)
                        Handle(inner);
                    break;
                case HttpRequestException hrex:
                    var data = resourceUri == null ? "" : $" ResourceURI: {resourceUri}";
                    //Logger.Log(hrex.Message, hrex.StackTrace, "Ensure the resource path or the server URI is correct." + data, LogType.Error);
                    break;
                default:
                    //Logger.Log(ex.Message, ex.StackTrace, null, LogType.Error);
                    break;
            }

            if (ex.InnerException != null)
                Handle(ex.InnerException);
        }
    }
}
