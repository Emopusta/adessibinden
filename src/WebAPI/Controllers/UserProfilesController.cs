using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Queries.GetByUserId;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : BaseController
{
    [HttpPost]
    public async Task<IDataResult<CreatedUserProfileResponse>> Create([FromBody] CreateUserProfileRequestDto createUserProfileRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreateUserProfileCommand(createUserProfileRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpPut]
    public async Task<IDataResult<UpdatedUserProfileResponse>> Update([FromBody] UpdateUserProfileRequestDto updateUserProfileRequestDto, CancellationToken cancellationToken)
    {
        var command = new UpdateUserProfileCommand(updateUserProfileRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<GetUserProfileResponse>> GetById([FromQuery] GetByUserIdUserProfileRequestDto getByUserIdUserProfileRequestDto, CancellationToken cancellationToken)
    {
        var query = new GetByUserIdUserProfileQuery(getByUserIdUserProfileRequestDto);
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }
}
