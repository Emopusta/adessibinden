using MediatR;

namespace Core.Application.CQRS;

public interface IQueryRequest<out TResponse> : IRequest<TResponse> { }
