using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create;

public class CreatePhoneInternalMemoryCommand : ICommandRequest<CreatedPhoneInternalMemoryResponse>
{
    public string Capacity { get; set; }
    public CreatePhoneInternalMemoryCommand(CreatePhoneInternalMemoryRequestDto phoneInternalMemoryCreateRequestDto)
    {
        Capacity = phoneInternalMemoryCreateRequestDto.Capacity;
    }
}
