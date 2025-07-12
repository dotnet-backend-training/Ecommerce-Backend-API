
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce_Backend_Core.Shared
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }    
        public HttpStatusCode StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, HttpStatusCode statusCode, string? message = null)
        {
            return new ApiResponse<T> {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> SuccessResponse(HttpStatusCode statusCode, string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ApiResponse<T> FailResponse(HttpStatusCode statusCode, List<string> errors, string? message = null)
        {
            return new ApiResponse<T>{
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> FailResponse(HttpStatusCode statusCode, string error, string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new List<string> { error },
                StatusCode = statusCode
            };
        }
    }
}
