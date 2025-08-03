using CommunicationPlatform.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CommunicationPlatform.API.CustomExceptionMiddleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong: {exception}", e);

            await HandleExceptionAsync(httpContext, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode;
        string message;
        switch (exception)
        {
            case InsufficientPlaceholdersException:
                statusCode = 400;
                message = exception.Message;
                break;
            case DbUpdateException:
                statusCode = 400;
                message = "Update failed";
                break;
            case ArgumentException:
                statusCode = 400;
                message = exception.Message;
                break;
            default:
                statusCode = 500;
                message = "Internal server error";
                break;
        }

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        var errorDetails = new ErrorDetails
        {
            StatusCode = statusCode,
            Message = message
        };

        await httpContext.Response.WriteAsync(errorDetails.ToString());
    }
}