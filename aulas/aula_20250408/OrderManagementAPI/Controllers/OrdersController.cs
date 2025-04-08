using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;

namespace OrderManagementAPI.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IOrderService orderService) : ControllerBase {
    private readonly IOrderService _orderService = orderService;

    [HttpGet]
    // [Route("orders")]
    public IActionResult GetOrders() {
        return Ok(_orderService.GetOrders());
    }

    [HttpGet("id")]
    // [Route("orderById")]
    public ActionResult GetOrder(int id) {
        var order = 
            _orderService.GetOrder(id);
        
        if (order == null) {
            throw new Exception("Order not found");
        }
        return Ok(order);
    }

    [HttpPost] 
    public ActionResult CreateOrder(Order order) {
        var createdOrder = _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), createdOrder);
    }

    [HttpDelete]
    public IActionResult DeleteOrder(int id) {
         _orderService.DeleteOrder(id);
         return Ok(true);
    }
}