namespace OnlineShop.Web.Models.Basket;


public class ShoppingCartModel
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItemModel> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
