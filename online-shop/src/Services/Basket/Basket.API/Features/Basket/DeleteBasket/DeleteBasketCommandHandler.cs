using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.DeleteBasket;
using BuildingBlocks.CQRS.Command;

namespace Basket.API.Features.Basket.DeleteBasket;
public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    private readonly IBasketRepository _basketRepository;

    public DeleteBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        var result = await _basketRepository.DeleteBasket(command.UserName, cancellationToken);
        return new DeleteBasketResult(result);
    }
}
