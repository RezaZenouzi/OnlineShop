using BuildingBlocks.CQRS.Command;

namespace Catalog.API.Models.DTOs.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
    ICommand<CreateProductResult>;