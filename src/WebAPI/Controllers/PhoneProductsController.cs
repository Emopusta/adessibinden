using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Commands.Delete;
using Application.Features.PhoneProducts.Commands.Update;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneProductsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedPhoneProductResponse>> Create([FromBody] CreatePhoneProductRequestDto createPhoneProductRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreatePhoneProductCommand(createPhoneProductRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpPut]
    public async Task<IDataResult<UpdatedPhoneProductResponse>> Update([FromBody] UpdatePhoneProductRequestDto updatePhoneProductRequestDto, CancellationToken cancellationToken)
    {
        var command = new UpdatePhoneProductCommand(updatePhoneProductRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete("{productId}")]
    public async Task<IDataResult<DeletedPhoneProductResponse>> Delete([FromRoute] DeletePhoneProductRequestDto deletePhoneProductRequestDto, CancellationToken cancellationToken)
    {
        var command = new DeletePhoneProductCommand(deletePhoneProductRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails([FromQuery] GetByIdDetailsPhoneProductRequestDto getByIdDetailsPhoneProductRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByIdDetailsPhoneProductQuery(getByIdDetailsPhoneProductRequestDto);
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }

    [HttpGet("UpdateDetails")]
    public async Task<IDataResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdForUpdateDetails([FromQuery] GetByIdDetailsForUpdatePhoneProductRequestDto getByIdDetailsForUpdatePhoneProductRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByIdDetailsForUpdatePhoneProductQuery(getByIdDetailsForUpdatePhoneProductRequestDto);
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }
}
