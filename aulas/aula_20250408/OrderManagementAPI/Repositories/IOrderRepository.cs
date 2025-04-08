using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repositories;

public interface IOrderRepository {
    List<Order> GetOrders();
    Order GetOrder(int orderId);
    Order CreateOrder(Order order);
    void DeleteOrder(int orderId);
    Order UpdateOrder(Order order);
}