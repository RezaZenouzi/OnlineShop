using MediatR;

namespace BuildingBlocks.Query;
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}

