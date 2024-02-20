using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Dtos;

public class CreatePhoneRAMRequestDto : IRequestDto
{
    public string Memory { get; set; }
}
