using Microsoft.AspNetCore.Diagnostics;

namespace Greenlink.HeroicCharacter.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var errorResponse = new
        {
            status = StatusCodes.Status500InternalServerError.ToString(),
            message = "An unexpected error occurred.",
            detailedMessage = exception.Message
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

        return true;
    }
}