using BuildingBlocks.Contracts.Events;
using BuildingBlocks.Contracts.Messaging;
using OrderService.Domain.Entities;

namespace OrderService.API.Orders;

public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IEventBus _eventBus;

    public OrderService(
        IOrderRepository repository,
        IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task<Guid> CreateOrderAsync(Guid productId, int quantity)
    {
        // 1. Create domain object
        var order = new Order(productId, quantity);

        // 2. Save order
        await _repository.AddAsync(order);

        // 3. Publish event 🔥
        await _eventBus.PublishAsync(
            new OrderCreatedEvent(order.Id, productId, quantity)
        );

        return order.Id;
    }
}
