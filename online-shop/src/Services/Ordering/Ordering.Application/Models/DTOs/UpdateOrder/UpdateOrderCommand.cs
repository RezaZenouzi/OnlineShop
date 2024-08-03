using BuildingBlocks.CQRS.Command;
using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;