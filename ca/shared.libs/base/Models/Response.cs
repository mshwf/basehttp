using System.ComponentModel;

namespace GET.PKI.Base
{
    //error: minus
    //success: zero
    //warning: positive
    public enum ErrorCode
    {
        [Description("Success")]
        Success = 0,

        [Description("Error Code 1")]
        ErrorCode1General = -1,
        
        [Description("Warning 1")]
        Warning = 1
    }
    public class Response
    {
        public Response(int code, bool status, string message, object result = null)
        {
            Code = code;
            Success = status;
            Message = message;
            Result = result;
        }
        public int? Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

    }

    public class SuccessResponse : Response
    {
        public SuccessResponse(string message, object result = null) : base(0, true, message, result) { }
    }

    public class FailedResponse : Response
    {
        public FailedResponse(string message, object result = null) : base(-1, false, message, result) { }
    }
}
