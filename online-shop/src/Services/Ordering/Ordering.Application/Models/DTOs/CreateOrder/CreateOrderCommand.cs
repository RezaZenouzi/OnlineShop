using BuildingBlocks.CQRS.Command;
using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.CreateOrder;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;