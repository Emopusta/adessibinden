using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Dtos;
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
    public async Task<IDataResult<CreatedColorResponse>> Create([FromBody] CreateColorRequestDto createColorRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreateColorCommand(createColorRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpDelete]
    public async Task<IDataResult<DeletedColorResponse>> Delete([FromBody] DeleteColorRequestDto deleteColorRequestDto, CancellationToken cancellationToken)
    {
        var command = new DeleteColorCommand(deleteColorRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<PaginateResponse<GetAllColorsListItemDto>>> GetAll([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        var query = new GetAllColorsQuery(pageRequest);
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<GetByIdColorResponse>> GetById([FromQuery] GetByIdColorsRequestDto getByIdColorsRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByIdColorQuery(getByIdColorsRequestDto);
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }
}
