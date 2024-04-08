using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;
using Core.Cache.Cache;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductQuery : IQueryRequest<GetByIdDetailsPhoneProductResponse>, IEmopCache
{
    public int ProductId { get; set; }

    public string CacheKey { get; set; }

    public GetByIdDetailsPhoneProductQuery(GetByIdDetailsPhoneProductRequestDto getByIdDetailsPhoneProductRequestDto)
    {
        ProductId = getByIdDetailsPhoneProductRequestDto.ProductId;

        CacheKey = $"GetByIdDetailsPhoneProductQuery {getByIdDetailsPhoneProductRequestDto.ProductId}";
    }
}
