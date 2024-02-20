using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;

public class GetByTitlePaginatedProductRequestDto : IRequestDto
{
    public string ProductTitleToSearch { get; set; }
}
