using Application.Features.PhoneProductFeatures.PhoneRAMs.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Rules
{
    public class PhoneRAMBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;

        public PhoneRAMBusinessRules(IGenericRepository<PhoneRAM> phoneRAMRepository)
        {
            _phoneRAMRepository = phoneRAMRepository;
        }

        public async Task PhoneRAMMemoryCannotDuplicate(string memory)
        {
            var phoneRAM = await _phoneRAMRepository.GetAsync(c => c.Memory == memory);
            if (phoneRAM != null) throw new BusinessException(PhoneRAMBusinessMessages.PhoneRAMMemoryDuplicated);

        }
    }
}
