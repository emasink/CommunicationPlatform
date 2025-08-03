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
    public void Map_WhenValidDto_ReturnsBody(BodyDto dto)
    {
        var expected = new BodyModel
        {
            Id = dto.Id,
            Text = dto.Text
        };

        var actual = _mapper.Map(dto);

        actual.Should().BeEquivalentTo(expected);
    }
}