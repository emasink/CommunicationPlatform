using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Persistence.Repositories;
using CommunicationPlatform.Persistence.Services;
using CommunicationPlatform.Repository;
using CommunicationPlatform.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CommunicationPlatform.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerMapper, CustomerMapper>();
        services.AddScoped<ITemplateRepository, TemplateRepository>();
        services.AddScoped<ITemplateMapper, TemplateMapper>();
        services.AddScoped<IBodyMapper, BodyMapper>();

        return services;
    }
}