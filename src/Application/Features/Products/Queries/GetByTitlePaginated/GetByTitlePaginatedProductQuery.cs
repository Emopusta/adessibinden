using Core.Application.Pipelines;
using Core.Application.Requests;
using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetByTitlePaginated
{
    public class GetByTitlePaginatedProductQuery : IQueryRequest<PaginateResponse<GetByTitlePaginatedProductDto>>
    {
        public PageRequest PageRequest{ get; set; }
        public string ProductTitleToSearch { get; set; }
    }
}
