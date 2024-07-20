using BuildingBlocks.CQRS.Command;
using Catalog.API.Exceptions;
using Catalog.API.Models.DTOs.Products.UpdateProduct;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.UpdateProduct;
public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IDocumentSession _session;

    public UpdateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException(command.Id);

        product.Name = command.Name;
        product.Description = command.Description;
        product.Category = command.Category;
        product.Price = command.Price;
        product.ImageFile = command.ImageFile;

        _session.Update(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
