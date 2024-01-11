using Core.Application.Pipelines;

namespace Application.Features.UserFavouriteProducts.Commands.Delete
{
    public class DeleteUserFavouriteProductCommand : ICommandRequest<DeletedUserFavouriteProductResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
