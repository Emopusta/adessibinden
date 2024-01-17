using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create
{
    public class CreatePhoneInternalMemoryCommandValidator : AbstractValidator<CreatePhoneInternalMemoryCommand>
    {
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;

        public CreatePhoneInternalMemoryCommandValidator(IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository)
        {
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;

            RuleFor(c => c.Capacity)
                .MustAsync(PhoneInternalMemoryCapacityCannotDuplicate).WithMessage(PhoneInternalMemoryBusinessMessages.PhoneInternalMemoryCapacityDuplicated);

        }
        private async Task<bool> PhoneInternalMemoryCapacityCannotDuplicate(string capacity, CancellationToken cancellationToken)
        {
            var phoneInternalMemory = await _phoneInternalMemoryRepository.GetAsync(c => c.Capacity == capacity);
            return phoneInternalMemory == null;
        }
    }
}
