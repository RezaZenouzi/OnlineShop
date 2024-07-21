namespace Basket.API.Models.DTOs.Basket.GetBasket;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);