using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;

public class CreatePhoneBrandRequestDto : IRequestDto
{
    public string Name { get; set; }
}
