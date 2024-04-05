using Core.Application.Responses;
using MediatR;

namespace Core.Application.CQRS;

public interface ICommandRequestHandler<TCommandRequest, TResponse> : IRequestHandler<TCommandRequest, TResponse>
    where TCommandRequest : ICommandRequest<TResponse> where TResponse : IResponse
{ }

