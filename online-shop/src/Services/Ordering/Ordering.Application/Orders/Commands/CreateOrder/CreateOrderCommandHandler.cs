using BuildingBlocks.CQRS.Command;
using Ordering.Application.Models.DTOs.CreateOrder;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}