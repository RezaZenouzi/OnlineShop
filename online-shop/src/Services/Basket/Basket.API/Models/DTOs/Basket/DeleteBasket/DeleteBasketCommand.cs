using BuildingBlocks.CQRS.Command;

namespace Basket.API.Models.DTOs.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;