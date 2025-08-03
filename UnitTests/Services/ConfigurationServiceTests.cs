using System.Collections.Generic;
using CommunicationPlatform.Core.Exceptions;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Persistence.Services;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace UnitTests.Services;

public class ConfigurationServiceTests
{
    private ConfigurationService _service;

    [Fact]
    public void GetDatabaseConnection_WhenKeyPresent_ReturnsValue()
    {
        _service = ArrangeConfigurationService(new Dictionary<string, string>
        {
            { "ConnectionString", "TestConnectionString" }
        });

        _service.GetDatabaseConnection().Should().Be("TestConnectionString");
    }

    [Fact]
    public void GetDatabaseConnection_WhenKeyMissing_ThrowsMissingConfigurationException()
    {
        _service = ArrangeConfigurationService(new Dictionary<string, string>
        {
            { "RandomKey", "TestConnectionString" }
        });

        _service.Invoking(x => x.GetDatabaseConnection())
            .Should()
            .ThrowExactly<MissingConfigurationException>();
    }

    private static ConfigurationService ArrangeConfigurationService(Dictionary<string, string> configData)
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(configData).Build();

        return new ConfigurationService(configuration);
    }
    
    
    private readonly CustomerMapper _mapper = new CustomerMapper();
    
}