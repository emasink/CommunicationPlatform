using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Services;
using CommunicationPlatform.Shared;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace UnitTests.Services;

public class TemplateServiceTests
{
    private readonly ITemplateRepository _templateRepository = Substitute.For<ITemplateRepository>();
    private readonly TemplateService _service;

    public TemplateServiceTests()
    {
        _service = new TemplateService(_templateRepository);
    }

    [Fact]
    public async Task GetAllTemplates_ReturnsTemplateList()
    {
        var expected = new List<TemplateEntity>();
        _templateRepository.GetTemplatesAsync().Returns(expected);

        var actual = await _service.GetAllAsync();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetTemplateById_WhenFound_ReturnsTemplate()
    {
        var expected = new TemplateEntity();
        const int id = 2;
        _templateRepository.GetTemplateByIdAsync(id).Returns(Task.FromResult(expected));

        var actual = await _service.GetByIdAsync(id);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task AddTemplate_Success_CallsRepository()
    {
        var template = new TemplateEntity();

        await _service.AddTemplate(template);

        await _templateRepository.Received(1).AddTemplateAsync(template);
    }

    [Fact]
    public async Task UpdateTemplate_WhenCalledWithValidId_UpdatesTemplateInDb()
    {
        var templateDto = new TemplateEntity();

        await _service.UpdateTemplateAsync(templateDto);

        await _templateRepository.Received(1).UpdateTemplateAsync(templateDto);
    }

    [Fact]
    public async Task DeleteTemplate_WhenCalledWithValidId_CallsRepositoryRemoveMethod()
    {
        const int templateId = 2;

        await _service.DeleteTemplate(templateId);

        await _templateRepository.Received(1).DeleteTemplateAsync(templateId);
    }
}
