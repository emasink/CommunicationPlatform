using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Services.Interfaces;
using CommunicationPlatform.Services.Services;
using CommunicationPlatform.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CommunicationPlatform.Services;

public static class ServiceRegistry
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IMessagingService, MessagingService>();
        services.AddScoped<IEmailBuilder, EmailBuilder>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IPlaceholderValidator, PlaceholderValidator>();

        return services;
    }
}