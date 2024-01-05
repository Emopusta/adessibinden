using Application.Features.UserProfiles.Commands.Dtos;
using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileCommand : ICommandRequest<UpdatedUserProfileResponse>
    {
        public UpdateUserProfileDto UpdateUserProfileDto { get; set; }
    }
}
