using Application.Features.CarBrands.Commands.Create;
using Application.Features.CarChassisTypes.Commands.Create;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarChassisTypesController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedCarChassisTypeResponse>> Create([FromBody] CreateCarChassisTypeCommand createCarChassisTypeCommand)
        {
            var response = await Mediator.Send(createCarChassisTypeCommand);

            return ReturnResult(response);
        }
    }
}
