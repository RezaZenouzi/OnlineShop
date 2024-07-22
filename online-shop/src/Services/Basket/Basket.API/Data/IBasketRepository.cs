using Basket.API.Models.Entities;

namespace Basket.API.Data;

public interface IBasketRepository
{
    #region Queries

    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);

    #endregion

    #region Commands

    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);

    #endregion
}