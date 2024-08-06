using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.DeleteBasket;
using BuildingBlocks.CQRS.Command;

namespace Basket.API.Features.Basket.CheckoutBasket;
public class CheckoutBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    private readonly IBasketRepository _basketRepository;

    public CheckoutBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        var result = await _basketRepository.DeleteBasket(command.UserName, cancellationToken);
        return new DeleteBasketResult(result);
    }
}
