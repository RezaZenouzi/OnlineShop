﻿using BuildingBlocks.CQRS.Command;
using Catalog.API.Models.DTOs.Products.CreateProduct;
using Catalog.API.Models.Entities;
using FluentValidation;
using Marten;

namespace Catalog.API.Features.Products.CreateProduct;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IDocumentSession _session;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(
        IDocumentSession session,
        IValidator<CreateProductCommand> validator)
    {
        _session = session;
        _validator = validator;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var resultOfValidator = await _validator.ValidateAsync(command, cancellationToken);
        if (resultOfValidator.Errors.Any())
        {
            string errors = string.Join('-', resultOfValidator.Errors.Select(x => x.ErrorMessage).ToList());
            throw new ValidationException(errors);
        }

        var product = new Product()
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
