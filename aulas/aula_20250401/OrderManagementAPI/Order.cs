using System;

namespace OrderManagementAPI;

public class Order
{
    public int Id { get; set; }
    public required string Customer { get; set; }
    public decimal Amount { get; set; }
}
