using Application.Features.PhoneProductFeatures.PhoneRAMs.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create
{
    public class CreatePhoneRAMCommandHandler : IRequestHandler<CreatePhoneRAMCommand, CreatedPhoneRAMResponse>
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;
        private readonly PhoneRAMBusinessRules _phoneRAMBusinessRules;

        public CreatePhoneRAMCommandHandler(IGenericRepository<PhoneRAM> phoneRAMRepository, PhoneRAMBusinessRules phoneRAMBusinessRules)
        {
            _phoneRAMRepository = phoneRAMRepository;
            _phoneRAMBusinessRules = phoneRAMBusinessRules;
        }

        public async Task<CreatedPhoneRAMResponse> Handle(CreatePhoneRAMCommand request, CancellationToken cancellationToken)
        {
            await _phoneRAMBusinessRules.PhoneRAMMemoryCannotDuplicate(request.Memory);

            PhoneRAM phoneRAM = new()
            {
                Memory = request.Memory,
            };

            PhoneRAM addedphoneRAM = await _phoneRAMRepository.AddAsync(phoneRAM);

            CreatedPhoneRAMResponse response = new()
            {
                Memory = addedphoneRAM.Memory,
            };

            return response;
        }
    }
}
