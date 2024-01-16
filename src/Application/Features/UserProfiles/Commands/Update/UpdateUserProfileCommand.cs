using Application.Features.UserProfiles.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileCommand : ICommandRequest<UpdatedUserProfileResponse>
    {
        public UpdateUserProfileDto UpdateUserProfileDto { get; set; }
    }
}
