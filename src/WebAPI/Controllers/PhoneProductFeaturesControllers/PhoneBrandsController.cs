using Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create;
using Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneBrandsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedPhoneBrandResponse>> Create([FromBody] CreatePhoneBrandCommand createPhoneBrandCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createPhoneBrandCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListPhoneBrandDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllListPhoneBrandQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
