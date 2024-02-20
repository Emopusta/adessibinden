using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;

public class GetByCreatorUserIdPaginatedRequestDto : IRequestDto
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int CreatorUserId { get; set; }
}
