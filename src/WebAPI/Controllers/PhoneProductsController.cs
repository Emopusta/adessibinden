using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.PhoneProducts.Queries.GetAllPhoneProductFeatures;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneProductsController : BaseController
    {

        [HttpPost]
        public async Task<IDataResult<CreatedPhoneProductResponse>> Create([FromBody] CreatePhoneProductCommand createPhoneProductCommand)
        {
            var response = await Mediator.Send(createPhoneProductCommand);

            return ReturnResult(response);
        }

        [HttpGet]
        public async Task<IDataResult<GetAllPhoneProductFeaturesDto>> GetAllPhoneProductFeatures()
        {
            var getAllPhoneProductFeaturesQuery = new GetAllPhoneProductFeaturesQuery();
            var result = await Mediator.Send(getAllPhoneProductFeaturesQuery);
            return ReturnResult(result);
        }
    }
}
