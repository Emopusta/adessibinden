using Application.Features.Products.Dtos;
using Core.Application.Pipelines;
using Core.Application.Requests;
using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetByTitlePaginated;

public class GetByTitlePaginatedProductQuery : IQueryRequest<PaginateResponse<GetByTitlePaginatedProductDto>>
{
    public PageRequest PageRequest{ get; set; }
    public string ProductTitleToSearch { get; set; }

    public GetByTitlePaginatedProductQuery(GetByTitlePaginatedProductRequestDto getByTitlePaginatedProductRequestDto, PageRequest pageRequest)
    {
        PageRequest = pageRequest;
        ProductTitleToSearch = getByTitlePaginatedProductRequestDto.ProductTitleToSearch;
    }
}
