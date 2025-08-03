using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Extensions;

public static class CustomerExtensions
{
    public static CustomerEntity ToDto(this CustomerModel customerModel)
    {
        var dto = new CustomerEntity();
        dto.Id = customerModel.Id;
        dto.Name = customerModel.Name;
        dto.Email = customerModel.Email;

        return dto;
    }
}