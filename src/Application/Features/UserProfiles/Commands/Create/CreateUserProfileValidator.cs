using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands.Create
{
    public class CreateUserProfileValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileValidator() {
            
            RuleFor(p => p.UserId).NotEmpty();
        
        }
    }
}
