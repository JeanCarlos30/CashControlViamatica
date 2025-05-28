using CashControl.Application.DTOs;

namespace CashControl.API.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        private ApiResponse(T? data, bool success, string? message)
        {
            Success = success;
            Message = message ?? "Operacion realizada con exito";
            Data = data;
        }

        public static ApiResponse<T> Ok(string? message, T? data)
        {
            return new ApiResponse<T>(data, true, message);
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>(default, false, message);
        }
    }

}
