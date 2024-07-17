using Catalog.API.Models.Entities;

namespace Catalog.API.Models.DTOs.Products.GetProducts;

public record GetProductsResult(IEnumerable<Product> Products);

