using CRM.API.Models;
using CRM.Domain.Models;
using System.Net;
using System.Text.Json;

namespace CRM.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }



        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // Varsayılan olarak Sunucu Hatası (500) kabul edelim
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Sunucu tarafında beklenmeyen bir hata oluştu.";

            // Eğer fırlatılan hata bizim yazdığımız ErrorModel (Domain Exception) ise status kodunu ayarlayabiliriz
            if (exception is ErrorModel)
            {
                statusCode = (int)HttpStatusCode.BadRequest; // 400
                message = exception.Message;
            }
            // İleride farklı exception türleriniz olursa buraya ekleyebilirsiniz (örn: KeyNotFoundException -> 404)

            context.Response.StatusCode = statusCode;

            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                Details = exception.StackTrace // İsteğe bağlı olarak sadece Development ortamında gösterilebilir
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }





    }
}
