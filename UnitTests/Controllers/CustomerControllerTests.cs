using CommunicationPlatform.API.Controllers;
using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace UnitTests;

public class CustomerControllerTests
{
    private readonly ICustomerService _customerService = Substitute.For<ICustomerService>();
    private readonly CustomerController _controller;
    private readonly CustomerEntity _customer = new();

    public CustomerControllerTests()
    {
        _controller = new CustomerController(_customerService);
    }

    [Fact]
    public async Task GetCustomerById_WhenCustomerExists_ReturnsCustomer()
    {
        var customer = new CustomerEntity { Id = 1, Name = "John Doe" };
        _customerService.GetByIdAsync(1).Returns(customer);

        var actual = await _controller.GetCustomerById(1);
        if (actual == null) throw new ArgumentNullException(nameof(actual));

        var okResult = actual.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be(customer);
    }

    [Fact]
    public async Task GetCustomerById_WhenCustomerDoesNotExist_ReturnsNotFound()
    {
        _customerService.GetByIdAsync(1).Returns((CustomerEntity)null);

        var actual = await _controller.GetCustomerById(1);

        var notFound = actual.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().Be("CustomerModel is not present in the database. ");
    }

    [Fact]
    public async Task GetCustomers_ReturnsAllCustomers()
    {
        var customers = new List<CustomerEntity>();
        _customerService.GetAllAsync().Returns(customers);

        var actual = await _controller.GetCustomers();

        var okResult = actual.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(customers);
    }

    [Fact]
    public async Task CreateCustomer_CallsServiceAndReturnsOk()
    {
        var request = new CreateCustomerRequest();
        var actual = await _controller.CreateCustomer(request);

        actual.Should().BeOfType<OkResult>();
        await _customerService
            .Received(1)
            .AddCustomerAsync(Arg.Is<CustomerEntity>(x => 
                x.Name == request.Name &&
                x.Email == request.Email));
    }

    [Fact]
    public async Task UpdateCustomer_WhenUpdateSucceeds_ReturnsOk()
    {
        var actual = await _controller.UpdateCustomer(_customer);

        await _customerService.Received(1).UpdateCustomerAsync(_customer);
        actual.Should().BeOfType<OkResult>();
    }

    [Fact]
    public async Task DeleteCustomer_CallsDeleteAndReturnsOk()
    {
        const int customerId = 5;

        var actual = await _controller.DeleteCustomer(customerId);

        await _customerService.Received(1).DeleteCustomerAsync(customerId);
        actual.Should().BeOfType<OkResult>();
    }
}
