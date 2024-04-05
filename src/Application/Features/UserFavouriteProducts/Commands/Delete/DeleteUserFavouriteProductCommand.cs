using Application.Features.UserFavouriteProducts.Dtos;
using Core.Application.CQRS;

namespace Application.Features.UserFavouriteProducts.Commands.Delete;

public class DeleteUserFavouriteProductCommand : ICommandRequest<DeletedUserFavouriteProductResponse>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }

    public DeleteUserFavouriteProductCommand(DeleteUserFavouriteProductRequestDto deleteUserFavouriteProductRequestDto)
    {
        UserId = deleteUserFavouriteProductRequestDto.UserId;
        ProductId = deleteUserFavouriteProductRequestDto.ProductId;
    }
}
