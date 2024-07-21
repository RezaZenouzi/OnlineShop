namespace Basket.API.Features.Basket.StoreBasket;
public class StoreBasketCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IDocumentSession _session;

    public StoreBasketCommandHandler(
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
