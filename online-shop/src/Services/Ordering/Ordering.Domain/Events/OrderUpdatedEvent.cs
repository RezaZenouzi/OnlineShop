using Ordering.Domain.Abstraction;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events;

public record OrderUpdatedEvent(Order order) : IDomainEvent;