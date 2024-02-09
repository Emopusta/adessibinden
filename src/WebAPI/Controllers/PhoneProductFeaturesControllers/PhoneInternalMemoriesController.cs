﻿using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create;
using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneInternalMemoriesController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedPhoneInternalMemoryResponse>> Create([FromBody] CreatePhoneInternalMemoryCommand createPhoneInternalMemoryCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createPhoneInternalMemoryCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListPhoneInternalMemoryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllListPhoneInternalMemoryQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
