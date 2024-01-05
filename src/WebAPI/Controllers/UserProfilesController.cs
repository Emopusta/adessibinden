using Application.Features.Colors.Commands.Create;
using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Update;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedUserProfileResponse>> Create([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            var response = await Mediator.Send(createUserProfileCommand);

            return ReturnResult(response);
        }

        [HttpPut]
        public async Task<IDataResult<UpdatedUserProfileResponse>> Update([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            var response = await Mediator.Send(updateUserProfileCommand);

            return ReturnResult(response);
        }
    }
}
