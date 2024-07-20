using BuildingBlocks.CQRS.Query;
using Catalog.API.Models.DTOs.Products.GetProducts;
using Catalog.API.Models.Entities;
using Marten;
using Marten.Pagination;

namespace Catalog.API.Features.Products.GetProducts;
public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly IDocumentSession _session;

    public GetProductsQueryHandler(IDocumentSession session)
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
