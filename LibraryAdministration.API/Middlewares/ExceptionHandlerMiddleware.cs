using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace LibraryAdministration.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex.Message);

                ProblemDetails problemDetails = new()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = ex.Message
                };

                await HandleError(context, problemDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                ProblemDetails problemDetails = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = ex.Message
                };

                await HandleError(context, problemDetails);
            }
        }

        private async Task HandleError(HttpContext context, ProblemDetails problemDetails)
        {
            var json = JsonSerializer.Serialize(problemDetails);
            context.Response.Clear();
            context.Response.StatusCode = (int)problemDetails.Status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}
