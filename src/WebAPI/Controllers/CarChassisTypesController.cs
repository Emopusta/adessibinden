using Application.Features.CarBrands.Commands.Create;
using Application.Features.CarChassisTypes.Commands.Create;
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
        public async Task<IActionResult> Create([FromBody] CreateCarChassisTypeCommand createCarChassisTypeCommand)
        {
            var response = await Mediator.Send(createCarChassisTypeCommand);

            return Ok(response);
        }
    }
}
