using Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;
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
    public async Task<IDataResult<CreatedPhoneRAMResponse>> Create([FromBody] CreatePhoneRAMCommand createPhoneRAMCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createPhoneRAMCommand, cancellationToken);
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
