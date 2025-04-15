using System;
using MonolitoDemo.Api.Model;
using MonolitoDemo.Api.Model.DTO;

namespace MonolitoDemo.Api.Services;

public interface ICustomerService
{
    public Customer Add(Customer customer);
    public List<Customer> GetAll();
    public List<CustomerDTO> GetAllName();
}
