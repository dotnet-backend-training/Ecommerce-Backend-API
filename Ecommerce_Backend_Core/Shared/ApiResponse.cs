
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce_Backend_Core.Shared
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }    

        public static ApiResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new ApiResponse<T> {
                Success = true,
                Message = message,
                Data = data
            };
        }
        public static ApiResponse<T> SuccessResponse(string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
            };
        }

        public static ApiResponse<T> FailResponse(List<string> errors, string? message = null)
        {
            return new ApiResponse<T>{
                Success = false,
                Message = message,
                Errors = errors
            };
        }
        public static ApiResponse<T> FailResponse(string error, string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new List<string> { error }
            };
        }
    }
}
