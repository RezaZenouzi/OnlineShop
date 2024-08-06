using BuildingBlocks.CQRS.Command;

namespace Basket.API.Models.DTOs.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckout) : ICommand<CheckoutBasketResult>;