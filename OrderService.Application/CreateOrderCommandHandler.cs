namespace OrderService.Application;

using BuildingBlocks.Contracts.Events;
using BuildingBlocks.Contracts.Messaging;
using OrderService.Domain.Entities;

public class CreateOrderCommandHandler
{
    private readonly IEventBus _eventBus;

    public CreateOrderCommandHandler(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task<Order> Handle(Guid productId, int quantity)
    {
        var order = new Order(productId, quantity);

        var orderCreatedEvent = new OrderCreatedEvent(
            order.Id,
            productId,
            quantity
        );

        await _eventBus.PublishAsync(orderCreatedEvent);

        return order;
    }
}
