using MediatR;

namespace Core.Application.CQRS;
public interface ICommandRequest<out TResponse> : IRequest<TResponse> { }

