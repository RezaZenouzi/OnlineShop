using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.GetBasket;
using BuildingBlocks.CQRS.Query;

namespace Basket.API.Features.Basket.GetBasket;
public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    private readonly IBasketRepository _basketRepository;

    public GetBasketQueryHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var cart = await _basketRepository.GetBasket(query.UserName, cancellationToken);
        return new GetBasketResult(cart);
    }
}
