using BuildingBlocks.CQRS.Query;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using Ordering.Application.Models.DTOs.GetOrdersByName;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;
public class GetOrdersByNameQueryHandler : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOrdersByNameQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await _applicationDbContext.Orders
            .Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(x => x.OrderName.Value.Contains(query.Name))
            .OrderBy(x => x.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetOrdersByNameResult(orders.ToOrderDtoList());
    }
}
