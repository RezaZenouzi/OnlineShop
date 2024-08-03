using FluentValidation;
using Ordering.Application.Models.DTOs.UpdateOrder;

namespace Ordering.Application.Models.Validators.UpdateOrder;

public class UpdateOrderCommandValidators : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidators()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}