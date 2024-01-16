using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create
{
    public class CreatePhoneInternalMemoryCommandHandler : IRequestHandler<CreatePhoneInternalMemoryCommand, CreatedPhoneInternalMemoryResponse>
    {
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;

        public CreatePhoneInternalMemoryCommandHandler(IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository)
        {
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;
        }

        public async Task<CreatedPhoneInternalMemoryResponse> Handle(CreatePhoneInternalMemoryCommand request, CancellationToken cancellationToken)
        {
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
