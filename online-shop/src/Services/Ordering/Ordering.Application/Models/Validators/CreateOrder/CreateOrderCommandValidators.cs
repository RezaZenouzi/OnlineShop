using FluentValidation;
using Ordering.Application.Models.DTOs.CreateOrder;

namespace Ordering.Application.Models.Validators.CreateOrder;

public class CreateOrderCommandValidators : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidators()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}