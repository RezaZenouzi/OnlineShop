﻿using Catalog.API.Models.DTOs.Products.CreateProduct;
using FluentValidation;

namespace Catalog.API.Models.Validators.Products.CreateProduct;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
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