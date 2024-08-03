using FluentValidation;
using Ordering.Application.Models.DTOs.DeleteOrder;

namespace Ordering.Application.Models.Validators.DeleteOrder;

public class DeleteOrderCommandValidators : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidators()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}