using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Commands.Delete;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
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
        [HttpDelete]
        public async Task<IDataResult<DeletedPhoneProductResponse>> Delete([FromBody] int productId)
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
    }
}
