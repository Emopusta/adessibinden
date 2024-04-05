using Application.Features.PhoneProductFeatures.PhoneModels.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList;

public class GetAllListPhoneModelQuery : IQueryRequest<ListResponse<GetAllListPhoneModelDto>>
{
}
