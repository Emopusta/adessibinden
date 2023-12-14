using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Create
{
    public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
    {
        public CreateColorCommandValidator() {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        }
    }
}
