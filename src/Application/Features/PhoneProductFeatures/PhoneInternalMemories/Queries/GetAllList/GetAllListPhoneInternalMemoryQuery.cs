﻿using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList;
public class GetAllListPhoneInternalMemoryQuery : IQueryRequest<ListResponse<GetAllListPhoneInternalMemoryDto>>
{
}
