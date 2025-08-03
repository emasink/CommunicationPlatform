using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Services.Models;
using CommunicationPlatform.Services.Services;
using CommunicationPlatform.Shared;
using NSubstitute;
using Xunit;

namespace UnitTests.Services;

public class MessagingServiceTests
{
    private  readonly ICustomerRepository _customerRepository = Substitute.For<ICustomerRepository>();
    private readonly ITemplateRepository _templateRepository = Substitute.For<ITemplateRepository>();
    private readonly IEmailBuilder _emailBuilder = Substitute.For<IEmailBuilder>();
    private readonly IEmailSender _emailSender = Substitute.For<IEmailSender>();
    
    private readonly MessagingService _service;

    public MessagingServiceTests()
    {
        _service = new MessagingService(_customerRepository, _templateRepository, _emailBuilder, _emailSender);
    }

    [Fact]
    public void TestName_Condition_Return()
    {
        const int templateId = 2;
        const int customerId = 5;
        const string emailBody = "content";
        var customerEntity = new CustomerEntity();
        var template = new TemplateEntity(){Body = new()};
        var placeholderValues = new Dictionary<string, string>();
        _customerRepository.GetCustomerByIdAsync(customerId).Returns(customerEntity);
        _templateRepository.GetTemplateByIdAsync(templateId).Returns(template);
        _emailBuilder.BuildEmailContentAsync(template.Body.Text, placeholderValues).Returns(emailBody);

        _service.SendMessageAsync(customerId, templateId, placeholderValues);

        _emailSender
            .Received(1)
            .SendEmailAsync(Arg.Is<EmailMessage>(m => 
                m.EmailAddress == customerEntity.Email && 
                m.EmailSubject == template.Subject && 
                m.EmailBody == emailBody));
    }
}