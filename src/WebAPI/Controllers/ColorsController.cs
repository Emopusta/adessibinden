using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {

        [HttpPost]
        public async Task<IDataResult<CreatedColorResponse>> Create([FromBody] CreateColorCommand createColorCommand)
        {
            var response = await Mediator.Send(createColorCommand);

            return ReturnResult(response);
        }

        [HttpDelete]
        public async Task<IDataResult<DeletedColorResponse>> Delete([FromBody] DeleteColorCommand deleteColorCommand)
        {
            var response = await Mediator.Send(deleteColorCommand);

            return ReturnResult(response);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IDataResult<GetListResponse<GetAllColorsListItemDto>>> GetAll([FromQuery] PageRequest pageRequest)
        {
            var getAllColorQuery = new GetAllColorsQuery() { PageRequest = pageRequest };
            var result = await Mediator.Send(getAllColorQuery);
            return ReturnResult(result);
        }

        [HttpGet("getById")]
        public async Task<IDataResult<GetByIdColorResponse>> GetById([FromQuery] GetByIdColorQuery getByIdColorQuery)
        {
            var result = await Mediator.Send(getByIdColorQuery);
            return ReturnResult(result);
        }
    }
}
