using Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneModelsController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedPhoneModelResponse>> Create([FromBody] CreatePhoneModelCommand createPhoneModelCommand)
        {
            var response = await Mediator.Send(createPhoneModelCommand);

            return ReturnResult(response);
        }
    }
}
