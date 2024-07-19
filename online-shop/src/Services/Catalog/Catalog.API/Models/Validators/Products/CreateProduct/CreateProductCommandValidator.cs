using Catalog.API.Models.DTOs.Products.CreateProduct;
using FluentValidation;

namespace Catalog.API.Models.Validators.Products.CreateProduct;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
    }
}
