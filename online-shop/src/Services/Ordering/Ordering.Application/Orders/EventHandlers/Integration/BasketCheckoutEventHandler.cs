using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler : IConsumer<BasketCheckoutEvent>
{
    public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        throw new NotImplementedException();
    }
}