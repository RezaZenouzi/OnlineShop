using MediatR;

namespace BuildingBlocks;
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}

