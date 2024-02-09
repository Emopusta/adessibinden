using Application.Features.CarBrands.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarBrandsController : BaseController
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IDataResult<CreatedCarBrandResponse>> Create([FromBody] CreateCarBrandCommand createCarBrandCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createCarBrandCommand, cancellationToken);
        return ReturnResult(response);
    }
}
