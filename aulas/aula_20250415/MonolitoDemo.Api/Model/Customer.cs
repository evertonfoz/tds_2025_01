using System;

namespace MonolitoDemo.Api.Model;

public class Customer(string name, 
    string phoneNumber, string address, int? customerId = null) : IEntity
{
    public int? CustomerId { get; set; } = customerId;
    public required string Name { get; set; } = name;
    public required string PhoneNumber { get; set; } = phoneNumber;
    public required string Address { get; set; } = address;

    public bool ValidateModel()
    {
       if (string.IsNullOrWhiteSpace(Name)) {
            throw new ArgumentNullException("Customer NAME is Null or Empty");
        }
        if (string.IsNullOrWhiteSpace(Address)) {
            throw new ArgumentNullException("Customer ADDRESS is Null or Empty");
        }
        if (string.IsNullOrWhiteSpace(PhoneNumber)) {
            throw new ArgumentNullException("Customer PHONE NUMBER is Null or Empty");
        }

        return true;
    }
}
