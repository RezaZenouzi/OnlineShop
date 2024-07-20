using BuildingBlocks.CQRS.Query;
using Catalog.API.Exceptions;
using Catalog.API.Models.DTOs.Products.GetProductById;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.GetProductById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@query}", query);
        var product = await _session.LoadAsync<Product>(query.ProductId, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(query.ProductId);

        return new GetProductByIdResult(product);
    }
}
