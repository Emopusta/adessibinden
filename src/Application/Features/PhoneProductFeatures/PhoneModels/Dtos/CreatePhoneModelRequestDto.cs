using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Dtos;

public class CreatePhoneModelRequestDto : IRequestDto
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
