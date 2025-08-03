using CommunicationPlatform.API.CustomExceptionMiddleware;

namespace CommunicationPlatform.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}