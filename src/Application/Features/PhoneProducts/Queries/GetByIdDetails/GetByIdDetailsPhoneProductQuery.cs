using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductQuery : IQueryRequest<GetByIdDetailsPhoneProductResponse>
{
    public int ProductId { get; set; }
    public GetByIdDetailsPhoneProductQuery(GetByIdDetailsPhoneProductRequestDto getByIdDetailsPhoneProductRequestDto)
    {
        ProductId = getByIdDetailsPhoneProductRequestDto.ProductId;
    }
}
