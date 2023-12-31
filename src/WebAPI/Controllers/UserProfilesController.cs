﻿using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Dtos;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetByUserId;
using Core.Utilities.Results;
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
        public async Task<IDataResult<UpdatedUserProfileResponse>> Update([FromBody] UpdateUserProfileDto updateUserProfileDto)
        {
            var updateUserProfileCommand = new UpdateUserProfileCommand { UpdateUserProfileDto = updateUserProfileDto };
            var response = await Mediator.Send(updateUserProfileCommand);

            return ReturnResult(response);
        }

        [HttpGet("getById")]
        public async Task<IDataResult<GetUserProfileResponse>> GetById([FromQuery] GetByUserIdUserProfileQuery getByIdColorQuery)
        {
            var result = await Mediator.Send(getByIdColorQuery);

            return ReturnResult(result);
        }
    }
}
