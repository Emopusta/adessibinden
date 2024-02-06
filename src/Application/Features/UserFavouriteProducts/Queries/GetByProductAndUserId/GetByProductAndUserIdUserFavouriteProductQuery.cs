using Core.Application.Pipelines;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;

public class GetByProductAndUserIdUserFavouriteProductQuery : IQueryRequest<GetByProductAndUserIdUserFavouriteProductResponse>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
