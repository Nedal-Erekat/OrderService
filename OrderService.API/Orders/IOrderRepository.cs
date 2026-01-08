using OrderService.Domain.Entities;
namespace OrderService.API.Orders;

public interface IOrderRepository
{
    Task AddAsync(Order order);
}
