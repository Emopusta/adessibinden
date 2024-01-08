using Application.Features.PhoneProducts.Commands.Create;
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
    }
}
