using BuildingBlocks.CQRS.Query;
using Catalog.API.Models.DTOs.Products.GetProducts;

namespace Catalog.API.Features.Products.GetProducts;
public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
