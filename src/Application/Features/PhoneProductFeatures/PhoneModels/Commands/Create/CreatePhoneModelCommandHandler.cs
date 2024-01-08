using Application.Features.PhoneProductFeatures.PhoneModels.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create
{
    public class CreatePhoneModelCommandHandler : IRequestHandler<CreatePhoneModelCommand, CreatedPhoneModelResponse>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
        private readonly PhoneModelBusinessRules _phoneModelBusinessRules;

        public CreatePhoneModelCommandHandler(IGenericRepository<PhoneModel> phoneModelRepository, PhoneModelBusinessRules phoneModelBusinessRules)
        {
            _phoneModelRepository = phoneModelRepository;
            _phoneModelBusinessRules = phoneModelBusinessRules;
        }

        public async Task<CreatedPhoneModelResponse> Handle(CreatePhoneModelCommand request, CancellationToken cancellationToken)
        {
            await _phoneModelBusinessRules.PhoneModelNameCannotDuplicate(request.Name);

            PhoneModel phoneInternalMemory = new()
            {
                BrandId = request.BrandId,
                Name = request.Name
            };

            PhoneModel addedPhoneInternalMemory = await _phoneModelRepository.AddAsync(phoneInternalMemory);

            CreatedPhoneModelResponse response = new()
            {
                BrandId = addedPhoneInternalMemory.BrandId,
                Name = addedPhoneInternalMemory.Name
            };

            return response;
        }
    }
}
