using BuildingBlocks.CQRS.Query;

namespace Basket.API.Models.DTOs.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

