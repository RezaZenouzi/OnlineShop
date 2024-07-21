using BuildingBlocks.CQRS.Query;

namespace Basket.API.Models.DTOs.Basket.GetBasket;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

