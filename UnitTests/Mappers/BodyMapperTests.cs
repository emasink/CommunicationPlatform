using AutoFixture.Xunit2;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;
using FluentAssertions;
using Xunit;

namespace UnitTests.Mappers;

public class BodyMapperTests
{
    private readonly BodyMapper _mapper = new();

    [Theory]
    [AutoData]
    public void Map_WhenValidDto_ReturnsBody(BodyEntity entity)
    {
        var expected = new BodyModel
        {
            Id = entity.Id,
            Text = entity.Text
        };

        var actual = _mapper.Map(entity);

        actual.Should().BeEquivalentTo(expected);
    }
}