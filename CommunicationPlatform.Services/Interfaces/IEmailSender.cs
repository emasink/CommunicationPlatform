using CommunicationPlatform.Services.Models;

namespace CommunicationPlatform.Services.Services;

public interface IEmailSender
{
    Task<string> SendEmailAsync(EmailMessage email);
}