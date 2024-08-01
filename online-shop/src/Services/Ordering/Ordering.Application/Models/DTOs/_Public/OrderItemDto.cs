namespace Ordering.Application.Models.DTOs._Public;

public record OrderItemDto(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal Price);