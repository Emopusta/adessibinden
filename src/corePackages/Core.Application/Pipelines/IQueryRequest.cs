using MediatR;

namespace Core.Application.Pipelines;

public interface IQueryRequest<out TResponse> : IRequest<TResponse> { }
