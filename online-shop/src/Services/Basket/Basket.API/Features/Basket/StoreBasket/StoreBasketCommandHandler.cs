using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.StoreBasket;
using BuildingBlocks.CQRS.Command;

namespace Basket.API.Features.Basket.StoreBasket;
public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    private readonly IBasketRepository _basketRepository;

    public StoreBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var userName = await _basketRepository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(userName.UserName);
    }
}
