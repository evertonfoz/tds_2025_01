using System;
using Microsoft.AspNetCore.Mvc;
using MonolitoDemo.Api.Model;
using MonolitoDemo.Api.Model.DTO;
using MonolitoDemo.Api.Services;

namespace MonolitoDemo.Api.Controller;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost] 
    public ActionResult CreateCustomer(Customer customer) {
        var createdCustomer = _customerService.Add(customer);
        return CreatedAtAction(nameof(CreateCustomer), createdCustomer);
    }

    [HttpGet("all")]
    public ActionResult<Customer> GetAll() {
        return Ok(_customerService.GetAll());
    }
    [HttpGet("allName")]
    public ActionResult<CustomerDTO> GetAllName() {
        return Ok(_customerService.GetAllName());
    }
}
