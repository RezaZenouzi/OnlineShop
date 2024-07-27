using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.StoreBasket;
using BuildingBlocks.CQRS.Command;
using Discount.Grpc;

namespace Basket.API.Features.Basket.StoreBasket;
public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProto;

    public StoreBasketCommandHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProto)
    {
        _basketRepository = basketRepository;
        _discountProto = discountProto;
    }

    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command, cancellationToken);
        var userName = await _basketRepository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(userName.UserName);
    }

    private async Task DeductDiscount(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        foreach (var shoppingCartItem in command.Cart.Items)
        {
            var coupon = await _discountProto.GetDiscountAsync(new GetDiscountRequest() { ProductName = shoppingCartItem.ProductName }, cancellationToken: cancellationToken);
            shoppingCartItem.Price -= coupon.Amount;
        }
    }
}
