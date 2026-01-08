using System.Text.Json;
using BuildingBlocks.Contracts.Messaging;

namespace OrderService.API.EventBus;

public class ConsoleEventBus : IEventBus
{
    public Task PublishAsync<TEvent>(TEvent @event) where TEvent : class
    {
        Console.WriteLine("📢 Event Published:");
        Console.WriteLine(JsonSerializer.Serialize(@event));

        return Task.CompletedTask;
    }

    public void Subscribe<T, TH>()
        where T : class
        where TH : IEventHandler<T>
    {
        Console.WriteLine(
            $"[SUBSCRIBED] Event: {typeof(T).Name}, Handler: {typeof(TH).Name}"
        );
    }
}
