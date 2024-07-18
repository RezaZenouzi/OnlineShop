using BuildingBlocks.CQRS.Command;

namespace Catalog.API.Models.DTOs.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
    ICommand<UpdateProductResult>;