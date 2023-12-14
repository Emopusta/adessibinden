using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateColorCommand createColorCommand)
        {
            var response = await Mediator.Send(createColorCommand);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteColorCommand deleteColorCommand)
        {
            var response = await Mediator.Send(deleteColorCommand);

            return Ok(response);
        }

    }
}
