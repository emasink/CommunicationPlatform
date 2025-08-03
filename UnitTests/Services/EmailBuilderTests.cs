using CommunicationPlatform.Services.Exceptions;
using CommunicationPlatform.Services.Interfaces;
using CommunicationPlatform.Services.Services;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace UnitTests.Services;

public class EmailBuilderTests
{
    private readonly IPlaceholderValidator _placeholderValidator = Substitute.For<IPlaceholderValidator>();
    
    private readonly EmailBuilder _builder;

    public EmailBuilderTests()
    {
        _builder = new EmailBuilder(_placeholderValidator);
    }

    [Fact]
    public async Task BuildEmail_WhenPlaceholdersProvided_ReturnsProductionStringHehe()
    {
        const string template = "Hello, {{name}}";
        var placeholderValues = new Dictionary<string, string> { { "name", "John" } };

        var actual = await _builder.BuildEmailContentAsync(template, placeholderValues);

        _placeholderValidator.Received(1).ValidatePlaceholders(template, placeholderValues);
        actual.Should().Be("Hello, John");
    }

    [Fact]
    public async Task BuildEmail_WhenValidatorThrowsException_RethrowsException()
    {
        const string template = "Hello";
        var placeholderValues = new Dictionary<string, string>();
        var exception = new Exception();
        _placeholderValidator
            .When(x => x.ValidatePlaceholders(template, placeholderValues))
            .Do(x => throw new InsufficientPlaceholdersException());

        _builder.Invoking(x => x.BuildEmailContentAsync(template, placeholderValues))
            .Should()
            .ThrowExactlyAsync<InsufficientPlaceholdersException>();
    }
}