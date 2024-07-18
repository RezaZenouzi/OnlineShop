using BuildingBlocks.CQRS.Query;

namespace Catalog.API.Models.DTOs.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

