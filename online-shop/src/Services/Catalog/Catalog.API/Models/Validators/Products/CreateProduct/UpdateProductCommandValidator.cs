using Catalog.API.Models.DTOs.Products.UpdateProduct;
using FluentValidation;

namespace Catalog.API.Models.Validators.Products.CreateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile)
            .NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}