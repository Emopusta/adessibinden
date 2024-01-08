using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Rules
{
    public class PhoneModelBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<PhoneModel> _phonemodelRepository;

        public PhoneModelBusinessRules(IGenericRepository<PhoneModel> phoneModelRepository)
        {
            _phonemodelRepository = phoneModelRepository;
        }

        public async Task PhoneModelNameCannotDuplicate(string name)
        {
            var phoneModel = await _phonemodelRepository.GetAsync(c => c.Name == name);
            if (phoneModel != null) throw new BusinessException(PhoneInternalMemoryBusinessMessages.PhoneInternalMemoryCapacityDuplicated);

        }
    }
}
