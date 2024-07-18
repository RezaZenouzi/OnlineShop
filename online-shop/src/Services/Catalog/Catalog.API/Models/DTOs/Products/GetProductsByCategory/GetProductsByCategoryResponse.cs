using Catalog.API.Models.Entities;

namespace Catalog.API.Models.DTOs.Products.GetProductsByCategory;

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
