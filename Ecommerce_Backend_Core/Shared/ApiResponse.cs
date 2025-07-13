using System.Net;

namespace Ecommerce_Backend_Core.Shared
{
    public abstract record ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }

        protected ApiResponse(
            bool success,
            string message,
            HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
    public record SuccessResponse : ApiResponse
    {
        public SuccessResponse(
            HttpStatusCode statusCode,
            string message)
            : base(true, message, statusCode) { }

        public static SuccessResponse Create(
            string message = "Success",
            HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(statusCode, message);
    }

    public record SuccessResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public SuccessResponse(
            HttpStatusCode statusCode,
            string message,
            T data)
            : base(true, message, statusCode)
        {
            Data = data;
        }

        public static SuccessResponse<T> Create(
            T data,
            string message = "Success",
            HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(statusCode, message, data);
    }

    public record FailResponse : ApiResponse
    {
        public List<string> Errors { get; } = [];
        public FailResponse(
            HttpStatusCode statusCode,
            string message,
             List<string> errors)
            : base(false, message, statusCode)
        {
            Errors = errors;
        }

        public FailResponse(
            HttpStatusCode statusCode,
            string message,
            string error
            )
            : base(false, message, statusCode)
        {
            Errors = [error];
        }

        public static FailResponse CreateWithErrors(
            string message,
            List<string> errors,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(statusCode, message, errors);

        public static FailResponse CreateWithError(
            string message,
            string error,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(statusCode: statusCode, message: message, error: error);
    }
}
