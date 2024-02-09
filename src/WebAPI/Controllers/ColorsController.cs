using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedColorResponse>> Create([FromBody] CreateColorCommand createColorCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createColorCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete]
    public async Task<IDataResult<DeletedColorResponse>> Delete([FromBody] DeleteColorCommand deleteColorCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(deleteColorCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<PaginateResponse<GetAllColorsListItemDto>>> GetAll([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        var getAllColorQuery = new GetAllColorsQuery() { PageRequest = pageRequest };
        var result = await Mediator.Send(getAllColorQuery, cancellationToken);
        return ReturnResult(result);
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<GetByIdColorResponse>> GetById([FromQuery] GetByIdColorQuery getByIdColorQuery, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(getByIdColorQuery, cancellationToken);
        return ReturnResult(result);
    }
}
