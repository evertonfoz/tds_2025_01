using System;
using MonolitoDemo.Api.Model;
using MonolitoDemo.Api.Model.DTO;

namespace MonolitoDemo.Api.Repository;

public interface ICustomerRepository
{
    public Customer Add(Customer customer);
    public List<Customer> GetAll();
    public List<CustomerDTO> GetAllName();
}
