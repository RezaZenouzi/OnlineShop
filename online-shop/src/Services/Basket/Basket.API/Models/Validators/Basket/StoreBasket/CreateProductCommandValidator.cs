using Basket.API.Models.DTOs.Basket.StoreBasket;
using FluentValidation;

namespace Basket.API.Models.Validators.Basket.StoreBasket;
public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName)
            .NotEmpty().WithMessage("UserName is required");
    }
}