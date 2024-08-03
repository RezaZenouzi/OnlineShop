using BuildingBlocks.CQRS.Query;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using Ordering.Application.Models.DTOs.GetOrdersByCustomer;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;
public class GetOrdersByCustomerQueryHandler : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOrdersByCustomerQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await _applicationDbContext.Orders
            .Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(x => x.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(x => x.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
    }
}
