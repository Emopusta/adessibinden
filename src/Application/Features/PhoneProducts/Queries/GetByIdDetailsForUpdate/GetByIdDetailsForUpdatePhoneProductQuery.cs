using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;

public class GetByIdDetailsForUpdatePhoneProductQuery : IQueryRequest<GetByIdDetailsForUpdatePhoneProductResponse>
{
    public int ProductId { get; set; }

    public GetByIdDetailsForUpdatePhoneProductQuery(GetByIdDetailsForUpdatePhoneProductRequestDto getByIdDetailsForUpdatePhoneProductRequestDto)
    {
        ProductId = getByIdDetailsForUpdatePhoneProductRequestDto.ProductId;
    }
}
