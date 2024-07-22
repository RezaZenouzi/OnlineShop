using Basket.API.Models.DTOs.Basket.DeleteBasket;
using FluentValidation;

namespace Basket.API.Models.Validators.Basket.StoreBasket;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName Id is required");
    }
}