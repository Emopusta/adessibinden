using Core.Application.Dtos;

namespace Application.Features.UserFavouriteProducts.Dtos;

public class DeleteUserFavouriteProductRequestDto : IRequestDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
