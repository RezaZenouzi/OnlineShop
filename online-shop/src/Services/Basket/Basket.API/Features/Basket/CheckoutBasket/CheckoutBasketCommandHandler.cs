using Basket.API.Data;
using Basket.API.Models.DTOs.Basket.CheckoutBasket;
using BuildingBlocks.CQRS.Command;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;

namespace Basket.API.Features.Basket.CheckoutBasket;
public class CheckoutBasketCommandHandler : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CheckoutBasketCommandHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
    {
        _basketRepository = basketRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetBasket(command.BasketCheckout.UserName, cancellationToken);
        var eventMessage = command.BasketCheckout.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await _publishEndpoint.Publish(eventMessage, cancellationToken);
        await _basketRepository.DeleteBasket(command.BasketCheckout.UserName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}
