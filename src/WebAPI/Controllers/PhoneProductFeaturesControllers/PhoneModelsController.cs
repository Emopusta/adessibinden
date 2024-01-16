using Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;
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

        [HttpGet]
        public async Task<IDataResult<List<GetAllListPhoneModelDto>>> GetAll()
        {
            var query = new GetAllListPhoneModelQuery();
            var response = await Mediator.Send(query);

            return ReturnResult(response);
        }

        [HttpGet("{BrandId}")]
        public async Task<IDataResult<List<GetByBrandIdPhoneModelDto>>> GetByBrandId([FromRoute] GetByBrandIdPhoneModelQuery getByBrandIdPhoneModelQuery)
        {
            var response = await Mediator.Send(getByBrandIdPhoneModelQuery);

            return ReturnResult(response);
        }
    }
}
