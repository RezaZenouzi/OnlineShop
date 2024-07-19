using Catalog.API.Models.DTOs.Products.DeleteProduct;
using FluentValidation;

namespace Catalog.API.Models.Validators.Products.CreateProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required");
    }
}