using System.Data;
using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Persistence.Extensions;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Repository;
using CommunicationPlatform.Shared;
using Microsoft.EntityFrameworkCore;

namespace CommunicationPlatform.Persistence.Repositories;
public class CustomerRepository(DatabaseContext context,
    ICustomerMapper customerMapper) 
    : ICustomerRepository
{
    public async Task<List<CustomerEntity>> GetCustomersAsync()
    {
        var customers = await context.Customers.ToListAsync();

        return customers
            .Select(x => new CustomerEntity { Id = x.Id, Email = x.Email, Name = x.Name })
            .ToList();
    }
    public async Task<int> AddCustomerAsync(CustomerEntity customer)
    {
        var entity = customerMapper.Map(customer);
        var addedEntity = context.Customers.Add(entity);
        await context.SaveChangesAsync();
        
        return addedEntity.Entity.Id;
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (customer != null) context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }

    public async Task<CustomerEntity?> UpdateCustomerAsync(CustomerEntity customer)
    {
        var entity = customerMapper.Map(customer);          
        var updatedCustomer = context.Customers.Update(entity).Entity.ToDto();
        await context.SaveChangesAsync();

        return updatedCustomer;
    }

    public async Task<CustomerEntity?> GetCustomerByIdAsync(int id)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        return customer?.ToDto();
    }
}