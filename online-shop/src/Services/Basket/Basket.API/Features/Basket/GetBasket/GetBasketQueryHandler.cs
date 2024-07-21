using Basket.API.Models.DTOs.Basket.GetBasket;
using Basket.API.Models.Entities;
using BuildingBlocks.CQRS.Query;
using Marten;

namespace Basket.API.Features.Basket.GetBasket;
public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    private readonly IDocumentSession _session;

    public GetBasketQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var cart = await _session
            .Query<ShoppingCart>()
            .FirstOrDefaultAsync(x => x.UserName == query.UserName);

        return new GetBasketResult(cart);
    }
}
