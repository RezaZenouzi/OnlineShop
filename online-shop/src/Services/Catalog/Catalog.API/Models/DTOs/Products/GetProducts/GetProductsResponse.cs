using Catalog.API.Models.Entities;

namespace Catalog.API.Models.DTOs.Products.GetProducts;

public record GetProductsResponse(IEnumerable<Product> Products);
