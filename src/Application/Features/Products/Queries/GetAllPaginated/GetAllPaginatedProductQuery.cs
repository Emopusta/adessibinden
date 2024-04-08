using Application.Features.Products.Dtos;
using Core.Application.CQRS;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Cache.Cache;

namespace Application.Features.Products.Queries.GetAllPaginated;

public class GetAllPaginatedProductQuery : IQueryRequest<PaginateResponse<GetAllPaginatedProductDto>>, IEmopCache
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey { get; }

    public GetAllPaginatedProductQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;

        CacheKey = $"GetAllPaginatedProductQuery";
    }
}
