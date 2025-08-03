using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Services.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Services.Services;

public class MessagingService(
    ICustomerRepository customerRepository,
    ITemplateRepository templateRepository,
    IEmailBuilder emailBuilder,
    IEmailSender emailSender)
    : IMessagingService
{
    public async Task<string> SendMessageAsync(int customerId, int templateId,
        Dictionary<string, string> placeholderValues)
    {
        var customer = await customerRepository.GetCustomerByIdAsync(customerId);
        var template = await templateRepository.GetTemplateByIdAsync(templateId);

        HandleNotFoundObjects(customer, template);

        var emailBody = await emailBuilder.BuildEmailContentAsync(template.Body.Text, placeholderValues);

        var emailMessage = new EmailMessage();
        emailMessage.EmailAddress = customer.Email;
        emailMessage.EmailSubject = template.Subject;
        emailMessage.EmailBody = emailBody;

        return await emailSender.SendEmailAsync(emailMessage);
    }

    private static void HandleNotFoundObjects(CustomerEntity? customer, TemplateEntity template)
    {
        if (customer == null)
            throw new ArgumentException("Customer not found");

        if (template == null)
            throw new ArgumentException("Template not found");
    }
}