using Application.Features.PhoneProductFeatures.PhoneRAMs.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;

public class GetAllListPhoneRAMQuery : IQueryRequest<ListResponse<GetAllListPhoneRAMDto>>
{
}
