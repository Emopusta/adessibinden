using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;
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
        [HttpDelete("/api/UserFavouriteProducts/UserId={userId}&ProductId={productId}")]
        public async Task<IDataResult<DeletedUserFavouriteProductResponse>> Delete([FromRoute] int userId, int productId)
        {
            var deleteUserFavouriteProductCommand = new DeleteUserFavouriteProductCommand() { ProductId = productId , UserId = userId};
            var response = await Mediator.Send(deleteUserFavouriteProductCommand);

            return ReturnResult(response);
        }

        [HttpGet]
        public async Task<IDataResult<GetByProductAndUserIdUserFavouriteProductResponse>> Create([FromQuery] GetByProductAndUserIdUserFavouriteProductQuery getByProductAndUserIdUserFavouriteProductQuery)
        {
            var response = await Mediator.Send(getByProductAndUserIdUserFavouriteProductQuery);

            return ReturnResult(response);
        }
    }
}
