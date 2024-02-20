using Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;
using Application.Features.PhoneProductFeatures.PhoneRAMs.Dtos;
using Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneRAMsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedPhoneRAMResponse>> Create([FromBody] CreatePhoneRAMRequestDto createPhoneRAMRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreatePhoneRAMCommand(createPhoneRAMRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListPhoneRAMDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllListPhoneRAMQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
