using Core.Application.Responses;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;

public class GetByProductAndUserIdUserFavouriteProductResponse : IResponse
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}