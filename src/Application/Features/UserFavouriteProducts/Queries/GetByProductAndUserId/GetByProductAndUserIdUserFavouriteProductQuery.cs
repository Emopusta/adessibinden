using Application.Features.UserFavouriteProducts.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;

public class GetByProductAndUserIdUserFavouriteProductQuery : IQueryRequest<GetByProductAndUserIdUserFavouriteProductResponse>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }

    public GetByProductAndUserIdUserFavouriteProductQuery(GetByProductAndUserIdUserFavouriteProductRequestDto getByProductAndUserIdUserFavouriteProductRequestDto)
    {
        UserId = getByProductAndUserIdUserFavouriteProductRequestDto.UserId;
        ProductId = getByProductAndUserIdUserFavouriteProductRequestDto.ProductId;
    }
}
