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
        var phoneInternalMemory = new PhoneInternalMemory()
        {
            Capacity = request.Capacity
        };

        var addedPhoneInternalMemory = await _phoneInternalMemoryRepository.AddAsync(phoneInternalMemory);

        var response = new CreatedPhoneInternalMemoryResponse()
        {
            Capacity = addedPhoneInternalMemory.Capacity,
        };
        return response;
    }
}
