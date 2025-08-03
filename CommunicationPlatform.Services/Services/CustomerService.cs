using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Services.Services;

internal class CustomerService(ICustomerRepository customerRepository)
    : ICustomerService
{
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await customerRepository.GetCustomersAsync();
    }

    public async Task<int> AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken = default)
    {
       return await customerRepository.AddCustomerAsync(customer);
    }

    public async Task UpdateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken = default)
    {
        await customerRepository.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
    {
        await customerRepository.DeleteCustomerAsync(id);
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await customerRepository.GetCustomerByIdAsync(id);
    }
}