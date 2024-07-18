using BuildingBlocks.CQRS.Query;
using Catalog.API.Models.DTOs.Products.GetProductsByCategory;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.GetProductsByCategory;
public class GetProductsByCategoryQueryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;

    public GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {@query}", query);

        var products = await _session
            .Query<Product>()
            .Where(x => x.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(products);
    }
}
