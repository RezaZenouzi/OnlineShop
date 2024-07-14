using MediatR;

namespace BuildingBlocks.CQRS.Command;

public interface ICommand : ICommand<Unit>
{
}
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
