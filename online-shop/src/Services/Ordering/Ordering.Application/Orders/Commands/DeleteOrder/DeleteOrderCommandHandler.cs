using BuildingBlocks.CQRS.Command;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Exceptions;
using Ordering.Application.Models.DTOs.DeleteOrder;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteOrderCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.OrderId);
        var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);

        if (order is null)
            throw new OrderNotFoundException(command.OrderId);

        _applicationDbContext.Orders.Remove(order);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResult(true);
    }
}