namespace CashControl.API.Middleware
{
    using CashControl.API.Utils;

    using System.Net;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Ejecuta el siguiente middleware / endpoint
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = ApiResponse<string>.Fail("Ocurrió un error interno: " + ex.Message);
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }

}
