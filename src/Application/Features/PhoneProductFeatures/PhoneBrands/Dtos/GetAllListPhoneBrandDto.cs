using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;

public class GetAllListPhoneBrandDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}