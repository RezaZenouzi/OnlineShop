using Basket.API.Models.Entities;
using BuildingBlocks.CQRS.Command;

namespace Basket.API.Models.DTOs.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;