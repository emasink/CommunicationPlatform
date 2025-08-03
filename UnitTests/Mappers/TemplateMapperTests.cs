using AutoFixture.Xunit2;
using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace UnitTests.Mappers;

public class TemplateMapperTests
{
    private readonly IBodyMapper _bodyMapepr = Substitute.For<IBodyMapper>();

    private readonly TemplateMapper _mapper;

    public TemplateMapperTests()
    {
        _mapper = new TemplateMapper(_bodyMapepr);
    }

    [Theory]
    [AutoData]
    public void Map_WhenValidDto_ReturnsTemplate(TemplateEntity entity)
    {
        var body = new BodyModel();
        _bodyMapepr.Map(entity.Body).Returns(body);

        var expected = new TemplateModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Subject = entity.Subject,
            BodyModel = body
        };

        var actual = _mapper.Map(entity);

        actual.Should().BeEquivalentTo(expected);
    }
}