using MediatR;

namespace Core.Application.Pipelines;
public interface ICommandRequest<out TResponse> : IRequest<TResponse> { }

