using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;

public class GetAllPaginatedProductRequestDto : IRequestDto
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
