using BuildingBlocks.CQRS.Command;
using Marten;

namespace Basket.API.Features.Basket.DeleteBasket;
public class DeleteBasketCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IDocumentSession _session;

    public DeleteBasketCommandHandler(IDocumentSession session)
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
