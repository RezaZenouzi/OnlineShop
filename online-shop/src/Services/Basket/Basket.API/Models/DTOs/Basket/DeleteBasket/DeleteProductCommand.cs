using BuildingBlocks.CQRS.Command;

namespace Basket.API.Models.DTOs.Basket.DeleteBasket;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;