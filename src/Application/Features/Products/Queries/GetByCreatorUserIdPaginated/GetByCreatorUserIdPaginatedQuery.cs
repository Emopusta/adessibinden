using Core.Application.Pipelines;
using Core.Application.Requests;
using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetByCreatorUserIdPaginated;

public class GetByCreatorUserIdPaginatedQuery : IQueryRequest<PaginateResponse<GetByCreatorUserIdPaginatedDto>>
{
    public PageRequest PageRequest { get; set; }
    public int CreatorUserId { get; set; }
}
