using Core.Application.Responses;

namespace Application.Features.UserFavouriteProducts.Commands.Delete
{
    public class DeletedUserFavouriteProductResponse : IResponse
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}