using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Dtos;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;
using Application.Features.UserFavouriteProducts.Queries.GetByUserId;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserFavouriteProductsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedUserFavouriteProductResponse>> Create([FromBody] CreateUserFavouriteProductRequestDto createUserFavouriteProductRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreateUserFavouriteProductCommand(createUserFavouriteProductRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete("{userId:int}/{productId:int}")]
    public async Task<IDataResult<DeletedUserFavouriteProductResponse>> Delete([FromRoute] int userId, int productId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserFavouriteProductCommand(userId, productId);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetByProductIdAndUserId")]
    public async Task<IDataResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetByProductAndUserId([FromQuery] GetByProductAndUserIdUserFavouriteProductRequestDto getByProductAndUserIdUserFavouriteProductRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByProductAndUserIdUserFavouriteProductQuery(getByProductAndUserIdUserFavouriteProductRequestDto);
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetByUserId")]
    public async Task<IDataResult<ListResponse<GetByUserIdUserFavouriteProductResponse>>> GetByUserId([FromQuery] GetByUserIdUserFavouriteProductRequestDto getByUserIdUserFavouriteProductRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByUserIdUserFavouriteProductQuery(getByUserIdUserFavouriteProductRequestDto);
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
