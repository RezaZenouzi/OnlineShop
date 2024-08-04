using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.GetOrdersByCustomer;

public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);