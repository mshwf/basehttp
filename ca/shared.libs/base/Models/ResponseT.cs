
namespace GET.PKI.Base
{
    public class Response<TData>
    {
        public Response(int? statusCode, bool success, string message, TData result = default)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
            Result = result;
        }
        public int? StatusCode { get; set; }
        //TODO: remove this, and use StatusCode instead
        public bool Success { get; set; }
        public string Message { get; set; }
        public TData Result { get; set; }
    }


    public class SuccessResponse<TData> : Response<TData>
    {
        public SuccessResponse(string message, TData result = default) : base(0, true, message, result) { }
    }

    public class FailedResponse<T> : Response<T>
    {
        public FailedResponse(string message, T result = default) : base(-1, false, message, result) { }
    }
}
