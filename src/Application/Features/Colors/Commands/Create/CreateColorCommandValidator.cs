using Application.Features.Colors.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.Colors.Commands.Create
{
    public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
    {
        private readonly IGenericRepository<Color> _colorRepository;
        public CreateColorCommandValidator(IGenericRepository<Color> colorRepository) {

            _colorRepository = colorRepository;

            RuleFor(c => c.Name).MustAsync(async (name, _) =>
            {
                return await ColorNameCannotDuplicate(name);

            }).WithMessage(ColorsBusinessMessages.ColorNameDuplicated);

            
        }

        private async Task<bool> ColorNameCannotDuplicate(string name)
        {
            return (await _colorRepository.GetAsync(c => c.Name == name)) == null;

        }
    }
}
