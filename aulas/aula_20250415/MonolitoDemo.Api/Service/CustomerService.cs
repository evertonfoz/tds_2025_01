using System;
using MonolitoDemo.Api.Model;
using MonolitoDemo.Api.Model.DTO;
using MonolitoDemo.Api.Repository;

namespace MonolitoDemo.Api.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public Customer Add(Customer customer)
    {
        customer.ValidateModel();

        customer = _customerRepository.Add(customer);

        return customer;
    }

    public List<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public List<CustomerDTO> GetAllName()
    {
        return _customerRepository.GetAllName();
    }
}
