using Application.Features.PhoneProductFeatures.PhoneBrands.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create
{
    public class CreatePhoneBrandCommandValidator : AbstractValidator<CreatePhoneBrandCommand>
    {
        private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;

        public CreatePhoneBrandCommandValidator(IGenericRepository<PhoneBrand> phoneBrandRepository)
        {
            _phoneBrandRepository = phoneBrandRepository;

            RuleFor(c => c.Name)
                .MustAsync(PhoneBrandNameCannotDuplicate).WithMessage(PhoneBrandsBusinessMessages.PhoneBrandNameDuplicated);
        }

        private async Task<bool> PhoneBrandNameCannotDuplicate(string name, CancellationToken cancellationToken)
        {
            var phoneBrand = await _phoneBrandRepository.GetAsync(c => c.Name == name);
            return phoneBrand == null;

        }
    }
}
