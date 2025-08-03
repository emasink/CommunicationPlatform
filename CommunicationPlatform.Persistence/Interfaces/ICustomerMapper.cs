using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Interfaces;

public interface ICustomerMapper
{
    CustomerModel Map(CustomerEntity customerEntity);
}