using Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneRAMsController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedPhoneRAMResponse>> Create([FromBody] CreatePhoneRAMCommand createPhoneRAMCommand)
        {
            var response = await Mediator.Send(createPhoneRAMCommand);

            return ReturnResult(response);
        }
    }
}
