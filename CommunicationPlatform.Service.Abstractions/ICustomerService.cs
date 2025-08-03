using CommunicationPlatform.Shared;

namespace CommunicationPlatform.ServiceAbstractions;

public interface ICustomerService
{
    Task<IEnumerable<CustomerEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<int> AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken = default);
    Task UpdateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default);
    Task<CustomerEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

}



