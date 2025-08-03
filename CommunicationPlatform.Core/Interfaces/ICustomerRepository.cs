using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Core.Interfaces;

public interface ICustomerRepository
{
    Task<List<CustomerEntity>> GetCustomersAsync();
    Task<CustomerEntity?> GetCustomerByIdAsync(int id);
    Task<int> AddCustomerAsync(CustomerEntity customer);
    Task DeleteCustomerAsync(int id);
    Task<CustomerEntity?> UpdateCustomerAsync(CustomerEntity customer);
}