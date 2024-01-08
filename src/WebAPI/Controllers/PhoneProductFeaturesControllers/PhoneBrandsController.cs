using Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PhoneProductFeaturesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBrandsController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedPhoneBrandResponse>> Create([FromBody] CreatePhoneBrandCommand createPhoneBrandCommand)
        {
            var response = await Mediator.Send(createPhoneBrandCommand);

            return ReturnResult(response);
        }
    }
}
