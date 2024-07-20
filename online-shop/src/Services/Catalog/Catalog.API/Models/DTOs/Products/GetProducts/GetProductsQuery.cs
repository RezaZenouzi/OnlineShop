using BuildingBlocks.CQRS.Query;

namespace Catalog.API.Models.DTOs.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

