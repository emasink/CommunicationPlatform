using CommunicationPlatform.Services.Exceptions;
using CommunicationPlatform.Services.Services;
using CommunicationPlatform.Services.Validators;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace UnitTests.Validators;

public class PlaceholderValidatorTests
{
    private readonly PlaceholderValidator _validator = new PlaceholderValidator();

    [Fact]
    public void IsValid_WhenPlaceholdersMatchBody_Returns()
    {
        var template = "{{name}} {{surname}} test text";
        var placeholderValues = new Dictionary<string, string>()
        {
            {"name", "John"}, 
            {"surname", "Doe"}
        };

        _validator.ValidatePlaceholders(template, placeholderValues);
    }
    
    [Fact]
    public void IsValid_WhenMoreValuesThanPlaceHolders_Returns()
    {
        var template = "{{name}} {{surname}} test text";
        var placeholderValues = new Dictionary<string, string>()
        {
            {"name", "John"}, 
            {"surname", "Doe"}, 
            {"age", "30"}
        };

        _validator.ValidatePlaceholders(template, placeholderValues);
    }
    
    [Fact]
    public void IsValid_WhenMorePlaceHoldersThanValues_Returns()
    {
        var template = "{{name}} {{surname}} test text";
        var placeholderValues = new Dictionary<string, string>()
        {
            {"name", "John"}
        };

        _validator.Invoking(x => x.ValidatePlaceholders(template, placeholderValues))
            .Should()
            .ThrowExactly<InsufficientPlaceholdersException>();
    }
}

