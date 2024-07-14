using BuildingBlocks.CQRS.Command;
using Catalog.API.Models.DTOs.Products.CreateProduct;
using Catalog.API.Models.Entities;

namespace Catalog.API.Features.Products.CreateProduct;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        // save to db

        return new CreateProductResult(product.Id);
    }
}
