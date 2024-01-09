using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos
{
    public class GetAllPhoneBrandPhoneProductFeatureDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
