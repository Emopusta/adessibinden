using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Queries.GetAll;
using Core.Application.Requests;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllColorsQuery getAllColorQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getAllColorQuery);
            return Ok(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdColorQuery getByIdColorQuery)
        {
            var result = await Mediator.Send(getByIdColorQuery);
            return Ok(result);
        }
    }
}
