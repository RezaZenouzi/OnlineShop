namespace Ordering.Application.Models.DTOs._Public;

public record PaymentDto(
    string CardName,
    string CardNumber,
    string Expiration,
    string Cvv,
    int PaymentMethod);