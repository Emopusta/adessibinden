using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;
using Application.Features.UserFavouriteProducts.Queries.GetByUserId;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavouriteProductsController : BaseController
    {

        [HttpPost]
        public async Task<IDataResult<CreatedUserFavouriteProductResponse>> Create([FromBody] CreateUserFavouriteProductCommand createUserFavouriteProductCommand)
        {
            var response = await Mediator.Send(createUserFavouriteProductCommand);

            return ReturnResult(response);
        }
        [HttpDelete("/api/UserFavouriteProducts/{userId}/{productId}")]
        public async Task<IDataResult<DeletedUserFavouriteProductResponse>> Delete([FromRoute] int userId, int productId)
        {
            var deleteUserFavouriteProductCommand = new DeleteUserFavouriteProductCommand() { ProductId = productId , UserId = userId};
            var response = await Mediator.Send(deleteUserFavouriteProductCommand);

            return ReturnResult(response);
        }

        [HttpGet]
        public async Task<IDataResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetByProductAndUserId([FromQuery] GetByProductAndUserIdUserFavouriteProductQuery getByProductAndUserIdUserFavouriteProductQuery)
        {
            var response = await Mediator.Send(getByProductAndUserIdUserFavouriteProductQuery);

            return ReturnResult(response);
        }

        [HttpGet("GetByUserId")]
        public async Task<IDataResult<ListResponse<GetByUserIdUserFavouriteProductResponse>>> GetByUserId([FromQuery] GetByUserIdUserFavouriteProductQuery getByUserIdUserFavouriteProductQuery)
        {
            var response = await Mediator.Send(getByUserIdUserFavouriteProductQuery);

            return ReturnResult(response);
        }
    }
}
