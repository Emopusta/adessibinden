using Core.Application.Responses;

namespace Application.Features.Products.Dtos;

public class GetByCreatorUserIdPaginatedDto : IResponse
{
    public string Title { get; set; }
    public int ProductId { get; set; }
}