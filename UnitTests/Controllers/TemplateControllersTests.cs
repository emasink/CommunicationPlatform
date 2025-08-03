using CommunicationPlatform.API.Controllers;
using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace UnitTests;

public class TemplateControllerTests
{
    private readonly TemplateEntity _template = new();

    private readonly ITemplateService _templateService = Substitute.For<ITemplateService>();
    
    private readonly TemplateController _controller;

    public TemplateControllerTests()
    {
        _controller = new TemplateController(_templateService);
    }

    [Fact]
    public async Task GetTemplateById_WhenTemplateExists_ReturnsTemplate()
    {
        var template = new TemplateEntity { Id = 1 };
        _templateService.GetByIdAsync(1).Returns(template);

        var actual = await _controller.GetTemplateById(1);
        if (actual == null) throw new ArgumentNullException(nameof(actual));

        var okResult = actual.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be(template);
    }

    [Fact]
    public async Task GetTemplateById_WhenTemplateDoesNotExist_ReturnsNotFound()
    {
        _templateService.GetByIdAsync(1)!.Returns((TemplateEntity)null);

        var actual = await _controller.GetTemplateById(1);

        var notFound = actual.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().Be("TemplateModel is not present in the database. ");
    }

    [Fact]
    public async Task GetTemplates_ReturnsAllTemplates()
    {
        var templates = new List<TemplateEntity>();
        _templateService.GetAllAsync().Returns(templates);

        var actual = await _controller.GetTemplates();

        var okResult = actual.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(templates);
    }

    [Fact]
    public async Task CreateTemplate_CallsServiceAndReturnsOk()
    {
        var request = new CreateTemplateRequest();
        var actual = await _controller.CreateTemplate(request);

        actual.Should().BeOfType<OkResult>();
        await _templateService.Received(1).AddTemplate(Arg.Is<TemplateEntity>(x =>
            x.Name == request.Name &&
            x.Subject == request.Subject));
    }

    [Fact]
    public async Task UpdateTemplate_WhenUpdateSucceeds_ReturnsOk()
    {
        var actual = await _controller.UpdateTemplate(_template);

        await _templateService.Received(1).UpdateTemplateAsync(_template);
        actual.Should().BeOfType<OkResult>();
    }

    [Fact]
    public async Task UpdateTemplate_WhenExceptionIsThrown_ReturnsBadRequest()
    {
        _templateService.UpdateTemplateAsync(_template)
            .Throws(new Exception());

        var actual = await _controller.UpdateTemplate(_template);

        actual.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task DeleteTemplate_CallsDeleteAndReturnsOk()
    {
        const int templateId = 5;

        var actual = await _controller.DeleteTemplate(templateId);

        await _templateService.Received(1).DeleteTemplate(templateId);
        actual.Should().BeOfType<OkResult>();
    }
}