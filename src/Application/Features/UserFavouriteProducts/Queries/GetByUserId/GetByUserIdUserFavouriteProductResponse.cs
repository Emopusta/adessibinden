using Core.Application.Responses;

namespace Application.Features.UserFavouriteProducts.Queries.GetByUserId
{
    public class GetByUserIdUserFavouriteProductResponse : IResponse
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }

    }

}