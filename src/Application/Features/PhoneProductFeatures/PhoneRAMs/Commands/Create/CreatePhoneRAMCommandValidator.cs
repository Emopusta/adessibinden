using Application.Features.PhoneProductFeatures.PhoneRAMs.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create
{
    public class CreatePhoneRAMCommandValidator : AbstractValidator<CreatePhoneRAMCommand>
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;

        public CreatePhoneRAMCommandValidator(IGenericRepository<PhoneRAM> phoneRAMRepository)
        {
            _phoneRAMRepository = phoneRAMRepository;

            RuleFor(c => c.Memory)
                .MustAsync(PhoneRAMMemoryCannotDuplicate).WithMessage(PhoneRAMBusinessMessages.PhoneRAMMemoryDuplicated);

        }

        private async Task<bool> PhoneRAMMemoryCannotDuplicate(string memory, CancellationToken cancellationToken)
        {
            var phoneRAM = await _phoneRAMRepository.GetAsync(c => c.Memory == memory);
            return phoneRAM == null;
        }
    }
}
