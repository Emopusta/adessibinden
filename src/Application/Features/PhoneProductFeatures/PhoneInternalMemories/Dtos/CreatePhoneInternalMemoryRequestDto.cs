using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Dtos;

public class CreatePhoneInternalMemoryRequestDto : IRequestDto
{
    public string Capacity { get; set; }
}
