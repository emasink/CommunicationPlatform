using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Mappers;

public class CustomerMapper : ICustomerMapper
{
    public CustomerModel Map(CustomerEntity customerEntity)
    {
        return new CustomerModel
        {
            Id = customerEntity.Id,
            Name = customerEntity.Name,
            Email = customerEntity.Email
        };
    }
}