using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Rules
{
    public class PhoneInternalMemoryBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;

        public PhoneInternalMemoryBusinessRules(IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository)
        {
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;
        }

        public async Task PhoneInternalMemoryCapacityCannotDuplicate(string capacity)
        {
            var color = await _phoneInternalMemoryRepository.GetAsync(c => c.Capacity == capacity);
            if (color != null) throw new BusinessException(PhoneInternalMemoryBusinessMessages.PhoneInternalMemoryCapacityDuplicated);

        }
    }
}
