using AutoFixture.Xunit2;
using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Shared;
using FluentAssertions;
using Xunit;

namespace UnitTests.Mappers;

public class CustomerMapperTests
{
    private readonly CustomerMapper _mapper = new();

    [Theory]
    [AutoData]
    public void Map_WhenNotNull_ReturnsCustomer(CustomerEntity entity)
    {
        entity.Should().NotBeNull("AutoFixture should generate a valid DTO");

        var expected = new CustomerModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email
        };

        var actual = _mapper.Map(entity);

        actual.Should().NotBeNull("mapper should return a non-null CustomerModel");
        actual.Should().BeEquivalentTo(expected);
    }
}