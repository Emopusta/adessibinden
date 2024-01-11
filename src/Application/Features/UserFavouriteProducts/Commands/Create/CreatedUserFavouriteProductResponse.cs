using Core.Application.Responses;

namespace Application.Features.UserFavouriteProducts.Commands.Create
{
    public class CreatedUserFavouriteProductResponse : IResponse
    {
        public int ProductId { get; set; }

        public int UserId { get; set; }
    }
}