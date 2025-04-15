using System;
using System.Linq;
using MonolitoDemo.Api.Data;
using MonolitoDemo.Api.Model;
using MonolitoDemo.Api.Model.DTO;

namespace MonolitoDemo.Api.Repository;

public class CustomerRepository(AppDbContext appDbContext) : ICustomerRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public Customer Add(Customer customer)
    {
        _appDbContext.Add(customer);
        _appDbContext.SaveChangesAsync();

        return customer;
    }

    public List<Customer> GetAll()
    {
        return [.. _appDbContext.Customers];
    }
    
    public List<CustomerDTO> GetAllName() {
        return [.. _appDbContext.Customers.Select(
            c => new CustomerDTO {
                CustomerId = c.CustomerId, 
                Name = c.Name
            })];
    }
}
