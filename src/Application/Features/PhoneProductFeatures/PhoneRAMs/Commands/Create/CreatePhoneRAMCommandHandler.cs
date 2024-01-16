using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create
{
    public class CreatePhoneRAMCommandHandler : IRequestHandler<CreatePhoneRAMCommand, CreatedPhoneRAMResponse>
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;
        public CreatePhoneRAMCommandHandler(IGenericRepository<PhoneRAM> phoneRAMRepository)
        {
            _phoneRAMRepository = phoneRAMRepository;
        }

        public async Task<CreatedPhoneRAMResponse> Handle(CreatePhoneRAMCommand request, CancellationToken cancellationToken)
        {

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
