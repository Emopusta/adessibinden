using Core.Application.Responses;
using MediatR;

namespace Core.Application.Pipelines
{
    public interface IQueryRequestHandler<TQueryRequest, TResponse> : IRequestHandler<TQueryRequest, TResponse>
        where TQueryRequest : IQueryRequest<TResponse> where TResponse : IResponse
    {
    }
}
