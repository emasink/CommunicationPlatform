using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Services.Services;
using CommunicationPlatform.Shared;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace UnitTests.Services;

public class CustomerServiceTests
{
    private readonly ICustomerRepository _customerRepository = Substitute.For<ICustomerRepository>();

    private readonly CustomerService _service;

    public CustomerServiceTests()
    {
        _service = new CustomerService(_customerRepository);
    }

    [Fact]
    public async Task GetAllCustomers_ReturnCustomerList()
    {
        var expected = new List<CustomerEntity>();
        _customerRepository.GetCustomersAsync().Returns(expected);

        var actual = await _service.GetAllAsync();

        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public async Task GetCustomerById_WhenFound_ReturnCustomer()
    {
        var expected = new CustomerEntity();
        const int id = 2;
        _customerRepository.GetCustomerByIdAsync(id)!.Returns(Task.FromResult(expected));

        var actual = await _service.GetByIdAsync(id);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task AddCustomer_Success_Returns()
    {
        var customer = new CustomerEntity();

        await _service.AddCustomerAsync(customer);

        await _customerRepository.Received(1).AddCustomerAsync(customer);
    }

    [Fact]
    public async Task UpdateCustomer_WhenCalledWithValidId_UpdatesCustomerInDb()
    {
        var customerDto = new CustomerEntity
        {
            Id = 1,
            Name = "Test",
            Email = "test@test.com"
        };

        await _service.UpdateCustomerAsync(customerDto);

        await _customerRepository.Received(1).UpdateCustomerAsync(customerDto);
    }
    
    [Fact]
    public async Task DeleteCustomer_WhenCalledWithValidId_CallsRepositoryRemoveMethod()
    {
        const int customerId = 2;
        
        await _service.DeleteCustomerAsync(customerId);

        await _customerRepository.Received(1).DeleteCustomerAsync(customerId);
    }
}