using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
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
    public async Task<IDataResult<CreatedUserFavouriteProductResponse>> Create([FromBody] CreateUserFavouriteProductCommand createUserFavouriteProductCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createUserFavouriteProductCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete("/api/UserFavouriteProducts/{userId:int}/{productId:int}")]
    public async Task<IDataResult<DeletedUserFavouriteProductResponse>> Delete([FromRoute] int userId, int productId, CancellationToken cancellationToken)
    {
        var deleteUserFavouriteProductCommand = new DeleteUserFavouriteProductCommand() { ProductId = productId , UserId = userId};
        var response = await Mediator.Send(deleteUserFavouriteProductCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetByProductIdAndUserId")]
    public async Task<IDataResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetByProductAndUserId([FromQuery] int userId, int productId, CancellationToken cancellationToken)
    {
        var query = new GetByProductAndUserIdUserFavouriteProductQuery() { UserId = userId, ProductId = productId };
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetByUserId")]
    public async Task<IDataResult<ListResponse<GetByUserIdUserFavouriteProductResponse>>> GetByUserId([FromQuery] int userId, CancellationToken cancellationToken)
    {
        var query = new GetByUserIdUserFavouriteProductQuery() { UserId = userId };
        var response = await Mediator.Send(query, cancellationToken);
        return ReturnResult(response);
    }
}
