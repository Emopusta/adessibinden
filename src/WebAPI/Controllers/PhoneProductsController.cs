using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Commands.Delete;
using Application.Features.PhoneProducts.Commands.Update;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneProductsController : BaseController
    {

        [HttpPost]
        public async Task<IDataResult<CreatedPhoneProductResponse>> Create([FromBody] CreatePhoneProductDto createPhoneProductDto)
        {
            var createPhoneProductCommand = new CreatePhoneProductCommand() { CreatePhoneProductDto = createPhoneProductDto};
            var response = await Mediator.Send(createPhoneProductCommand);

            return ReturnResult(response);
        }
        [HttpPut]
        public async Task<IDataResult<UpdatedPhoneProductResponse>> Update([FromBody] UpdatePhoneProductDto updatePhoneProductDto)
        {
            var createPhoneProductCommand = new UpdatePhoneProductCommand() { UpdatePhoneProductDto = updatePhoneProductDto };
            var response = await Mediator.Send(createPhoneProductCommand);

            return ReturnResult(response);
        }
        [HttpDelete("ProductId={productId}")]
        public async Task<IDataResult<DeletedPhoneProductResponse>> Delete([FromRoute] int productId)
        {
            var createPhoneProductCommand = new DeletePhoneProductCommand() { ProductId = productId};
            var response = await Mediator.Send(createPhoneProductCommand);

            return ReturnResult(response);
        }

        [HttpGet("{productId}")]
        public async Task<IDataResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails([FromRoute] int productId)
        {
            var getAllPhoneProductFeaturesQuery = new GetByIdDetailsPhoneProductQuery() { ProductId = productId };
            var result = await Mediator.Send(getAllPhoneProductFeaturesQuery);
            return ReturnResult(result);
        }

        [HttpGet("{productId}/update-details")]
        public async Task<IDataResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdForUpdateDetails([FromRoute] int productId)
        {
            var getAllPhoneProductFeaturesQuery = new GetByIdDetailsForUpdatePhoneProductQuery() { ProductId = productId };
            var result = await Mediator.Send(getAllPhoneProductFeaturesQuery);
            return ReturnResult(result);
        }
    }
}
