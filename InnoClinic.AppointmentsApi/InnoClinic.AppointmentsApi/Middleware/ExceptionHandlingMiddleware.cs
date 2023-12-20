using Application.Services.Interfaces;
using Domain.Exceptions;
using InnoClinic.AppointmentsApi.Models;
using System.Text.Json;

namespace InnoClinic.AppointmentsApi.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerDbService loggerDbService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, loggerDbService);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, ILoggerDbService loggerDbService)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new ErrorResponseModel
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = exception.Message
            };

            await Task.WhenAll(
                    loggerDbService.LogAsync(exception),
                    httpContext.Response.WriteAsync(JsonSerializer.Serialize(response))
                );
        }
    }
}
