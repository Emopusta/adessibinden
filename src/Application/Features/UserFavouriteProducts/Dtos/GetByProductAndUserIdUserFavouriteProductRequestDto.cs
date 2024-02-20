using Core.Application.Dtos;

namespace Application.Features.UserFavouriteProducts.Dtos;

public class GetByProductAndUserIdUserFavouriteProductRequestDto : IRequestDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
