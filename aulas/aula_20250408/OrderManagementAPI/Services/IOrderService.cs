using System.Collections.Generic;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services;

public interface IOrderService {
    List<Order> GetOrders();
    Order GetOrder(int orderId);
    Order CreateOrder(Order order);
    void DeleteOrder(int orderId);
    Order UpdateOrder(Order order);
}