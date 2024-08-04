using BuildingBlocks.Pagination;
using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.GetOrders;

public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);