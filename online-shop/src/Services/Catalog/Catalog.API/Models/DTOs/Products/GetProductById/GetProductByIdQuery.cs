using BuildingBlocks.CQRS.Query;

namespace Catalog.API.Models.DTOs.Products.GetProductById;

public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdResult>;

