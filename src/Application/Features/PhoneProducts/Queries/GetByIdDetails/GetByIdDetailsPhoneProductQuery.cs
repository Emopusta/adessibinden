using Application.CacheGroups;
using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;
using Core.Cache.Cache;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductQuery : IQueryRequest<GetByIdDetailsPhoneProductResponse>, IEmopCache
{
    public int ProductId { get; set; }
    public string CacheKey { get; }

    public GetByIdDetailsPhoneProductQuery(GetByIdDetailsPhoneProductRequestDto getByIdDetailsPhoneProductRequestDto)
    {
        CacheKey = $"PhoneProductGetByIdDetails {getByIdDetailsPhoneProductRequestDto.ProductId}";

        ProductId = getByIdDetailsPhoneProductRequestDto.ProductId;
    }
}
