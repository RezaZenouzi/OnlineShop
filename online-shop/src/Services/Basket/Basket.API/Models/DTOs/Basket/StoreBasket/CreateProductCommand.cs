using BuildingBlocks.CQRS.Command;

namespace Basket.API.Models.DTOs.Basket.StoreBasket;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
    ICommand<CreateProductResult>;