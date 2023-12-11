using Application.Features.Colors.Commands.Create;
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
            CreatedColorResponse response = await Mediator.Send(createColorCommand);

            return Ok(response);
        }

    }
}
