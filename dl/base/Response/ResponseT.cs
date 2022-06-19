using System.Diagnostics;

namespace GET.Spooler.Base
{
    [DebuggerDisplay("Success= {Success}, Message= {Message}")]
    public class Response<TData>
    {
        public Response()
        {
            StatusCode = StatusCode.SUCCESS;
        }
        public Response(StatusCode statusCode, string message, TData result = default)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
        public StatusCode StatusCode { get; set; }

        public bool Success { get { return StatusCode == StatusCode.SUCCESS; } }
        public string Message { get; set; }
        public TData Result { get; set; }
    }
}