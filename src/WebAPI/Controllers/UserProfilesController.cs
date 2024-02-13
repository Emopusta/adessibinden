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
    public async Task<IDataResult<CreatedUserProfileResponse>> Create([FromBody] CreateUserProfileCommand createUserProfileCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createUserProfileCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpPut]
    public async Task<IDataResult<UpdatedUserProfileResponse>> Update([FromBody] UpdateUserProfileDto updateUserProfileDto, CancellationToken cancellationToken)
    {
        var updateUserProfileCommand = new UpdateUserProfileCommand { UpdateUserProfileDto = updateUserProfileDto };
        var response = await Mediator.Send(updateUserProfileCommand, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<GetUserProfileResponse>> GetById([FromQuery] int userId, CancellationToken cancellationToken)
    {
        var getByIdColorQuery = new GetByUserIdUserProfileQuery() { UserId = userId };
        var result = await Mediator.Send(getByIdColorQuery, cancellationToken);
        return ReturnResult(result);
    }
}
