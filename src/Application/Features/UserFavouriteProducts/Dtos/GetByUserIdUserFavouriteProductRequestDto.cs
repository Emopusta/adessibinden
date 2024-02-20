using Core.Application.Dtos;

namespace Application.Features.UserFavouriteProducts.Dtos;

public class GetByUserIdUserFavouriteProductRequestDto : IRequestDto
{
    public int UserId { get; set; }
}
