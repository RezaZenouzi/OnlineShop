using BuildingBlocks.CQRS.Query;

namespace Ordering.Application.Models.DTOs.GetOrdersByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;