using Core.Application.Pipelines;
using Core.Application.Requests;
using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetAllPaginated
{
    public class GetAllPaginatedProductQuery : IQueryRequest<PaginateResponse<GetAllPaginatedProductDto>>
    {
        public PageRequest PageRequest { get; set; }
    }
}
