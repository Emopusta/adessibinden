using Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;

public class GetAllListPhoneBrandQuery : IQueryRequest<ListResponse<GetAllListPhoneBrandDto>>
{

}
