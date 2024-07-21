namespace Basket.API.Features.Basket.GetBasket;
public class GetBasketQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly IDocumentSession _session;

    public GetBasketQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await _session
            .Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new GetProductsResult(products);
    }
}
