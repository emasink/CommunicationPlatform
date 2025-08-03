using CommunicationPlatform.Services.Models;

namespace CommunicationPlatform.Services.Services;

public class EmailSender : IEmailSender
{
    public Task<string> SendEmailAsync(EmailMessage email)
    {
        return Task.FromResult(string.Concat(email.EmailAddress, '\n', email.EmailSubject, '\n', email.EmailBody));
    }
}