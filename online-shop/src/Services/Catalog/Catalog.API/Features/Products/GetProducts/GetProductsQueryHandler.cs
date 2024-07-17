using BuildingBlocks.CQRS.Query;
using Catalog.API.Models.DTOs.Products.GetProducts;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.GetProducts;
public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductsQueryHandler> _logger;

    public GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductsQueryHandler.Handle called with {@query}", query);
        var products = await _session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductsResult(products);
    }
}
