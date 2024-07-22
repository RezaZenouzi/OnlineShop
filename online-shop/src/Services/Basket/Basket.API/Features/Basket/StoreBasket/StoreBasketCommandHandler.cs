using Basket.API.Models.DTOs.Basket.StoreBasket;
using Basket.API.Models.Entities;
using BuildingBlocks.CQRS.Command;
using Marten;

namespace Basket.API.Features.Basket.StoreBasket;
public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    private readonly IDocumentSession _session;

    public StoreBasketCommandHandler(
        IDocumentSession session)
    {
        _session = session;
    }

    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = new ShoppingCart()
        {

        };

        _session.Store(shoppingCart);
        await _session.SaveChangesAsync(cancellationToken);

        return new StoreBasketResult("");
    }
}
