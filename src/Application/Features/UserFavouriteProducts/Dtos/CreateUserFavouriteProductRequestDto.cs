using Core.Application.Dtos;

namespace Application.Features.UserFavouriteProducts.Dtos;

public class CreateUserFavouriteProductRequestDto : IRequestDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
