using BuildingBlocks.CQRS.Query;

namespace Catalog.API.Models.DTOs.Products.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;

