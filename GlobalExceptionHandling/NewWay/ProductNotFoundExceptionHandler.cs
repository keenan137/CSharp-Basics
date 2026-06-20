using GlobalExceptionHandling.CustomExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.NewWay
{
    public class ProductNotFoundExceptionHandler(ILogger<ProductNotFoundExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ProductNotFoundException e)
            {
                return false;
            }

            var problemDetails = new ProblemDetails
            {
                Title = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = (int)e.StatusCode;
            _logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
