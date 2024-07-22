using Basket.API.Models.DTOs.Basket.DeleteBasket;
using Basket.API.Models.Entities;
using BuildingBlocks.CQRS.Command;
using Marten;

namespace Basket.API.Features.Basket.DeleteBasket;
public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    private readonly IDocumentSession _session;

    public DeleteBasketCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        _session.Delete<ShoppingCart>(1);
        await _session.SaveChangesAsync(cancellationToken);

        return new DeleteBasketResult(true);
    }
}
