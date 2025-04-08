using OrderManagementAPI.Models;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Services;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [
        new Order { 
            OrderId = 1, 
            Customer = new Customer {CustomerId = 1, Name= "John"},
            Amount = 150
        },
         new Order { 
            OrderId = 2, 
            Customer = new Customer {CustomerId = 2, Name= "Mary"},
            Amount = 250
        }
    ];
    public List<Order> GetOrders()
    {
        return _orders;
    }

    public Order GetOrder(int orderId)
    {
        // var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
        // if (order == null) {
        //     throw new Exception("Order not found");
        // }
        // return order;
        return _orders.First(o => o.OrderId == orderId);
    }

    public Order CreateOrder(Order order)
    {
        order.OrderId = _orders.Count+1;
        _orders.Add(order);
        return order;
    }

    public void DeleteOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null) {
            _orders.Remove(order);
        }
    }

    public Order UpdateOrder(Order order)
    {
        var orderToUpdate =
            _orders.FirstOrDefault(o => o.OrderId == order.OrderId) ?? throw new Exception("Order not found");
            
        orderToUpdate.CustomerId = order.CustomerId;
        orderToUpdate.Customer = order.Customer;
        orderToUpdate.Amount = order.Amount;

        return orderToUpdate;
    }
}