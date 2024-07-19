using BuildingBlocks.CQRS.Command;
using Catalog.API.Models.DTOs.Products.CreateProduct;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.CreateProduct;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IDocumentSession _session;

    public CreateProductCommandHandler(
        IDocumentSession session)
    {
        _session = session;
    }

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

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
