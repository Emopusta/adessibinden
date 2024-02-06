using Application.Features.Colors.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand> // we can catch duplication with entity framework configuration
{
    //private readonly IGenericRepository<Color> _colorRepository;
    //public CreateColorCommandValidator(IGenericRepository<Color> colorRepository) {

    //    _colorRepository = colorRepository;

    //    RuleFor(c => c.Name)
    //        .MustAsync(ColorNameCannotDuplicate).WithMessage(ColorsBusinessMessages.ColorNameDuplicated);

    //}
    
    //private async Task<bool> ColorNameCannotDuplicate(string name, CancellationToken cancellationToken)
    //{
    //    return (await _colorRepository.GetAsync(c => c.Name == name)) == null;

    //}
}
