using Microsoft.AspNetCore.Mvc;

namespace OrderService.API.Orders;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var orderId = await _orderService.CreateOrderAsync(
            request.ProductId,
            request.Quantity
        );

        return Ok(new { OrderId = orderId });
    }
}

public record CreateOrderRequest(
    Guid ProductId,
    int Quantity
);
