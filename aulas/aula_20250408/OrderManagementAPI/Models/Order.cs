namespace OrderManagementAPI.Models;

public class Order {
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer;
    public decimal Amount { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) {
            return false;
        }
        return OrderId == ((Order) obj).OrderId;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}