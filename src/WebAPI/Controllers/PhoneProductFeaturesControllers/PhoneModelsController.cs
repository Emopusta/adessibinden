using Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;
using Application.Features.PhoneProductFeatures.PhoneModels.Dtos;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneModelsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedPhoneModelResponse>> Create([FromBody] CreatePhoneModelRequestDto createPhoneModelRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreatePhoneModelCommand(createPhoneModelRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListPhoneModelDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllListPhoneModelQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetByBrandId")]
    public async Task<IDataResult<ListResponse<GetByBrandIdPhoneModelDto>>> GetByBrandId([FromQuery] int brandId, CancellationToken cancellationToken)
    {
        var query = new GetByBrandIdPhoneModelQuery(){ BrandId = brandId};
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
