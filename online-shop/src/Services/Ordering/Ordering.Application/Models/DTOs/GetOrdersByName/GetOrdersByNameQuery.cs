using BuildingBlocks.CQRS.Query;

namespace Ordering.Application.Models.DTOs.GetOrdersByName;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;