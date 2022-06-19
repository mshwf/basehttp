namespace GET.Spooler.Base
{
    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse(string message = "Success", T result = default) : base(StatusCode.SUCCESS, message, result) { }
        public SuccessResponse(T result = default) : base(StatusCode.SUCCESS, "Success", result) { }
        //public SuccessResponse() : base(StatusCode.SUCCESS, "Success", result) { }
    }

    public class FailedResponse<T> : Response<T>
    {
        public FailedResponse(string message, T result = default) : base(StatusCode.UNEXPECTED, message, result) { }
    }

    public class NotSavedResponse<T> : Response<T>
    {
        public NotSavedResponse(string message = "The Transaction Not Saved on DATABASE", T result = default) : base(StatusCode.NOT_SAVED, message, result) { }
    }
    public class LicenseNotExistsResponse<T> : Response<T>
    {
        public LicenseNotExistsResponse(T result = default) : base(StatusCode.LICENSE_NOT_EXISTS, StatusCode.LICENSE_NOT_EXISTS.ToDescriptionString(), result) { }
    }
}