namespace OnlineShop.Web.Models.Ordering;

public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);