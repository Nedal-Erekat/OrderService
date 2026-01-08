namespace OrderService.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Order(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
