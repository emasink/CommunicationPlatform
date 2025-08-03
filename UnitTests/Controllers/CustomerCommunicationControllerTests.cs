using CommunicationPlatform.API.Controllers;
using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace UnitTests;

public class CustomerCommunicationControllerTests
{
    private readonly IMessagingService _messagingService = Substitute.For<IMessagingService>();
    private readonly ILogger<CustomerCommunicationController> _logger = Substitute.For<ILogger<CustomerCommunicationController>>();

    private readonly CustomerCommunicationController _controller;

    public CustomerCommunicationControllerTests()
    {
        _controller = new CustomerCommunicationController(_messagingService, _logger);
    }

    [Fact]
    public async Task SendMessage_WhenSuccess_ReturnsOk()
    {
        var request = new SendEmailRequest();

        var actual = await _controller.SendEmailAsync(request);

        actual.Should().BeOfType<OkResult>();
        _messagingService.Received(1)
            .SendMessageAsync(request.CustomerId, request.TemplateId, request.PlaceholderValues);
    }
}