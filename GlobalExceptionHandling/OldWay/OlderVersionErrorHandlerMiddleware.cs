using GlobalExceptionHandling.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GlobalExceptionHandling.CustomMiddleware
{
    public class OlderVersionErrorHandlerMiddleware(RequestDelegate _next, ILogger<OlderVersionErrorHandlerMiddleware> _logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = ex switch
                {
                    BaseException e => (int)e.StatusCode,
                    _ => StatusCodes.Status500InternalServerError
                };

                var problemDetails = new ProblemDetails
                {
                    Status = response.StatusCode,
                    Title = ex.Message
                };
                _logger.LogError(ex.Message);
                var result = JsonSerializer.Serialize(problemDetails);
                await response.WriteAsync(result);
            }
        }
    }
}
