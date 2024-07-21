namespace Basket.API.Models.DTOs.Basket.StoreBasket;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);