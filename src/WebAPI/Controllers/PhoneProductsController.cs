using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Commands.Delete;
using Application.Features.PhoneProducts.Commands.Update;
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
    public async Task<IDataResult<CreatedPhoneProductResponse>> Create([FromBody] CreatePhoneProductDto createPhoneProductDto, CancellationToken cancellationToken)
    {
        var createPhoneProductCommand = new CreatePhoneProductCommand() { CreatePhoneProductDto = createPhoneProductDto};
        var response = await Mediator.Send(createPhoneProductCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpPut]
    public async Task<IDataResult<UpdatedPhoneProductResponse>> Update([FromBody] UpdatePhoneProductDto updatePhoneProductDto, CancellationToken cancellationToken)
    {
        var createPhoneProductCommand = new UpdatePhoneProductCommand() { UpdatePhoneProductDto = updatePhoneProductDto };
        var response = await Mediator.Send(createPhoneProductCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete("{productId}")]
    public async Task<IDataResult<DeletedPhoneProductResponse>> Delete([FromRoute] int productId, CancellationToken cancellationToken)
    {
        var createPhoneProductCommand = new DeletePhoneProductCommand() { ProductId = productId};
        var response = await Mediator.Send(createPhoneProductCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("{productId}")]
    public async Task<IDataResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails([FromRoute] int productId, CancellationToken cancellationToken)
    {
        var getAllPhoneProductFeaturesQuery = new GetByIdDetailsPhoneProductQuery() { ProductId = productId };
        var result = await Mediator.Send(getAllPhoneProductFeaturesQuery, cancellationToken);
        return ReturnResult(result);
    }

    [HttpGet("UpdateDetails/{productId}")]
    public async Task<IDataResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdForUpdateDetails([FromRoute] int productId, CancellationToken cancellationToken)
    {
        var getAllPhoneProductFeaturesQuery = new GetByIdDetailsForUpdatePhoneProductQuery() { ProductId = productId };
        var result = await Mediator.Send(getAllPhoneProductFeaturesQuery, cancellationToken);
        return ReturnResult(result);
    }
}
