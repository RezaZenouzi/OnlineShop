using BuildingBlocks.Pagination;

namespace Ordering.Application.Models.DTOs.GetOrders;

public record GetOrdersRequest(PaginationRequest PaginationRequest);