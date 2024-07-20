namespace Catalog.API.Models.DTOs.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);