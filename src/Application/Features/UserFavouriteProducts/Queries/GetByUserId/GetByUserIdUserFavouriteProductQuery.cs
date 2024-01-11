using Core.Application.Pipelines;

namespace Application.Features.UserFavouriteProducts.Queries.GetByUserId
{
    public class GetByUserIdUserFavouriteProductQuery : IQueryRequest<List<GetByUserIdUserFavouriteProductResponse>>
    {
        public int UserId { get; set;}
    }
}
