using BuildingBlocks.CQRS.Query;
using Catalog.API.Models.DTOs.Products.GetProductsByCategory;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.GetProductsByCategory;
public class GetProductsByCategoryQueryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    private readonly IDocumentSession _session;

    public GetProductsByCategoryQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {

        var products = await _session
            .Query<Product>()
            .Where(x => x.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(products);
    }
}
