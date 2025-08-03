using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCommunicationController(
    IMessagingService messagingService,
    ILogger<CustomerCommunicationController> logger)
    : Controller
{
    [HttpPost]
    [Route("/sendEmail")]
    public async Task<IActionResult> SendEmailAsync([FromBody] SendEmailRequest request)
    {
        var email = await messagingService.SendMessageAsync(request.CustomerId, request.TemplateId,
            request.PlaceholderValues);

        logger.LogInformation(@"Email sent {Email content}", email);

        return Ok();
    }
}