using BuildingBlocks.CQRS.Query;
using Catalog.API.Exceptions;
using Catalog.API.Models.DTOs.Products.GetProductById;
using Catalog.API.Models.Entities;
using Marten;

namespace Catalog.API.Features.Products.GetProductById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    private readonly IDocumentSession _session;

    public GetProductByIdQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(query.ProductId, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(query.ProductId);

        return new GetProductByIdResult(product);
    }
}
