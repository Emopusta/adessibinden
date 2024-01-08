using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create
{
    public class CreatePhoneInternalMemoryCommandHandler : IRequestHandler<CreatePhoneInternalMemoryCommand, CreatedPhoneInternalMemoryResponse>
    {
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;
        private readonly PhoneInternalMemoryBusinessRules _phoneInternalMemoryBusinessRules;

        public CreatePhoneInternalMemoryCommandHandler(IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository, PhoneInternalMemoryBusinessRules phoneInternalMemoryBusinessRules)
        {
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;
            _phoneInternalMemoryBusinessRules = phoneInternalMemoryBusinessRules;
        }

        public async Task<CreatedPhoneInternalMemoryResponse> Handle(CreatePhoneInternalMemoryCommand request, CancellationToken cancellationToken)
        {
            await _phoneInternalMemoryBusinessRules.PhoneInternalMemoryCapacityCannotDuplicate(request.Capacity);

            PhoneInternalMemory phoneInternalMemory = new()
            {
                Capacity = request.Capacity
            };

            PhoneInternalMemory addedPhoneInternalMemory = await _phoneInternalMemoryRepository.AddAsync(phoneInternalMemory);

            CreatedPhoneInternalMemoryResponse response = new()
            {
                Capacity = addedPhoneInternalMemory.Capacity,
            };

            return response;
        }
    }
}
