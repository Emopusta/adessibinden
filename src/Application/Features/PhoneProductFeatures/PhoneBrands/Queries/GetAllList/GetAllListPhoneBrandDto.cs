using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;

public class GetAllListPhoneBrandDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}