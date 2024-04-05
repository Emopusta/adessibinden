using Application.Features.UserFavouriteProducts.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.UserFavouriteProducts.Queries.GetByUserId;

public class GetByUserIdUserFavouriteProductQuery : IQueryRequest<ListResponse<GetByUserIdUserFavouriteProductResponse>>
{
    public int UserId { get; set;}

    public GetByUserIdUserFavouriteProductQuery(GetByUserIdUserFavouriteProductRequestDto getByUserIdUserFavouriteProductRequestDto)
    {
        UserId = getByUserIdUserFavouriteProductRequestDto.UserId;
    }
}
