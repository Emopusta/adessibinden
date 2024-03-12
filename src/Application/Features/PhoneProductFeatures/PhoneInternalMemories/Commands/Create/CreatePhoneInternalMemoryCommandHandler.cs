using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create;

public class CreatePhoneInternalMemoryCommandHandler : ICommandRequestHandler<CreatePhoneInternalMemoryCommand, CreatedPhoneInternalMemoryResponse>
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

        var addedPhoneInternalMemory = await _phoneInternalMemoryRepository.AddAsync(phoneInternalMemory);

        CreatedPhoneInternalMemoryResponse response = new()
        {
            Capacity = addedPhoneInternalMemory.Capacity,
        };
        return response;
    }
}
