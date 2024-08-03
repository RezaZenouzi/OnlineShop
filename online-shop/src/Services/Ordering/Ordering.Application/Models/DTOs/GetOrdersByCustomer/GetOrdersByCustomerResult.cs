using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.GetOrdersByCustomer;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);