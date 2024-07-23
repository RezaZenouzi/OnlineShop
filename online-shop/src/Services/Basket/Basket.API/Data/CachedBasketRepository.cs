using Basket.API.Models.Entities;

namespace Basket.API.Data;

public class CachedBasketRepository : IBasketRepository
{
    private readonly IBasketRepository _repository;

    public CachedBasketRepository(IBasketRepository repository)
    {
        _repository = repository;
    }

    #region Queries

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await _repository.GetBasket(userName, cancellationToken);
        return basket;
    }

    #endregion

    #region Commands

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        var result = await _repository.StoreBasket(basket, cancellationToken);
        return result;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteBasket(userName, cancellationToken);
        return result;
    }

    #endregion

}