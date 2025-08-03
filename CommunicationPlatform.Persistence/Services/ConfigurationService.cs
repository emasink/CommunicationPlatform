using CommunicationPlatform.Core.Exceptions;
using CommunicationPlatform.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CommunicationPlatform.Persistence.Services;

public class ConfigurationService(IConfiguration configuration) : IConfigurationService
{
    public string GetDatabaseConnection()
    {
        var connectionString = configuration.GetSection("ConnectionString").Value;

        if (connectionString.IsNullOrEmpty()) throw new MissingConfigurationException();

        return connectionString!;
    }
}