using Application.Features.PhoneProductFeatures.PhoneModels.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;

public class GetByBrandIdPhoneModelQuery : IQueryRequest<ListResponse<GetByBrandIdPhoneModelDto>>
{
    public int BrandId { get; set; }
}
