using BuildingBlocks.CQRS.Command;

namespace Ordering.Application.Models.DTOs.DeleteOrder;

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;