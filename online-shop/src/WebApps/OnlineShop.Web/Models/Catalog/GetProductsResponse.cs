namespace OnlineShop.Web.Models.Catalog;

public record GetProductsResponse(IEnumerable<ProductModel> Products);