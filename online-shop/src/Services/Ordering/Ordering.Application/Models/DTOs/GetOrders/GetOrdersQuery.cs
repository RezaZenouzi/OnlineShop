using BuildingBlocks.CQRS.Query;
using BuildingBlocks.Pagination;

namespace Ordering.Application.Models.DTOs.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;