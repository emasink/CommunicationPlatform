using System.Net;
using System.Text;
using CommunicationPlatform.API.CustomExceptionMiddleware;
using Fare;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public class ExceptionMiddlewareTests
{
    private readonly ILogger<ExceptionMiddleware> _logger = Substitute.For<ILogger<ExceptionMiddleware>>();

    private ExceptionMiddleware _middleware; 
    
    [Fact]
    public async Task InvokeAsync_WhenExceptionThrown_ShouldWriteToResponseBodyAndSet500()
    {
        var context = new DefaultHttpContext();
        var responseBody = new MemoryStream();
        context.Response.Body = responseBody;
        var exception = new Exception("Error");
        RequestDelegate next = _ => throw exception;
        _middleware = new ExceptionMiddleware(next, _logger);

        await _middleware.InvokeAsync(context);
        
        context.Response.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        context.Response.ContentType.Should().Be("application/json");
        responseBody.Seek(0, SeekOrigin.Begin);
        var responseText = new StreamReader(responseBody, Encoding.UTF8).ReadToEnd();
        responseText.Should().Contain("Internal server error");
        responseText.Should().Contain(((int)HttpStatusCode.InternalServerError).ToString());
    }
}
