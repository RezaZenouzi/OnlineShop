using BuildingBlocks.CQRS.Command;

namespace Catalog.API.Models.DTOs.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;