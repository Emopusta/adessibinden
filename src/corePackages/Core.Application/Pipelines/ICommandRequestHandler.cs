using Core.Application.Responses;
using MediatR;

namespace Core.Application.Pipelines
{
    public interface ICommandRequestHandler<TCommandRequest, TResponse> : IRequestHandler<TCommandRequest, TResponse>
        where TCommandRequest : ICommandRequest<TResponse> where TResponse : IResponse
    {
    }
}
