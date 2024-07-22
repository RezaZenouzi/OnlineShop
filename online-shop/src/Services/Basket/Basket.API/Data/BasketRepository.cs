using Basket.API.Models.Entities;

namespace Basket.API.Data;

public class BasketRepository : IBasketRepository
{
    #region Queries

    public Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Commands

    public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion
}