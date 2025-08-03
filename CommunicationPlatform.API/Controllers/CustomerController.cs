using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : Controller
{
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await customerService.GetByIdAsync(id);

        return customer == null ? 
            NotFound("CustomerModel is not present in the database. ") : 
            Ok(customer);
    }

    [HttpGet]
    [Route("customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await customerService.GetAllAsync();

        return Ok(customers);
    }

    [HttpPost]
    [Route("createCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        var customerEntity = new CustomerEntity
        {
            Name = request.Name,
            Email = request.Email
        };

        await customerService.AddCustomerAsync(customerEntity);

        return Ok();
    }

    [HttpPost]
    [Route("updateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerEntity customer)
    {
        await customerService.UpdateCustomerAsync(customer);
        return Ok();
    }

    [HttpDelete]
    [Route("deleteCustomer")]
    public async Task<IActionResult> DeleteCustomer([FromBody] int customerId)
    {
        await customerService.DeleteCustomerAsync(customerId);

        return Ok();
    }
}