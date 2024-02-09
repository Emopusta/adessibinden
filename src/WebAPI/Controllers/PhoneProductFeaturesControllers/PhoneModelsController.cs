using Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;
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
    public async Task<IDataResult<CreatedPhoneModelResponse>> Create([FromBody] CreatePhoneModelCommand createPhoneModelCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createPhoneModelCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListPhoneModelDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllListPhoneModelQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("{BrandId}")]
    public async Task<IDataResult<ListResponse<GetByBrandIdPhoneModelDto>>> GetByBrandId([FromRoute] GetByBrandIdPhoneModelQuery getByBrandIdPhoneModelQuery, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(getByBrandIdPhoneModelQuery, cancellationToken);
        return ReturnResult(response);
    }
}
