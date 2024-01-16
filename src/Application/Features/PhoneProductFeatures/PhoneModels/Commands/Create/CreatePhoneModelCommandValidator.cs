using Application.Features.PhoneProductFeatures.PhoneModels.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create
{
    public class CreatePhoneModelCommandValidator : AbstractValidator<CreatePhoneModelCommand>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;

        public CreatePhoneModelCommandValidator(IGenericRepository<PhoneModel> phoneModelRepository)
        {
            _phoneModelRepository = phoneModelRepository;

            RuleFor(c => c.Name).MustAsync(async (name, _) =>
            {
                return await PhoneModelNameCannotDuplicate(name);

            }).WithMessage(PhoneModelBusinessMessages.PhoneModelNameDuplicated);

        }

        private async Task<bool> PhoneModelNameCannotDuplicate(string name)
        {
            var phoneModel = await _phoneModelRepository.GetAsync(c => c.Name == name);
            return phoneModel == null;

        }
    }
}
