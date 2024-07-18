using BuildingBlocks.CQRS.Command;
using Catalog.API.Models.DTOs.Products.DeleteProduct;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.DeleteProduct;
public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IDocumentSession _session;

    public DeleteProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        _session.Delete<Product>(command.Id);
        await _session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
