using Application.Features.CarBrands.Commands.Create;
using Application.Features.Colors.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarBrandCommand createCarBrandCommand)
        {
            var response = await Mediator.Send(createCarBrandCommand);

            return Ok(response);
        }
    }
}
