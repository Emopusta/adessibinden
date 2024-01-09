using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos
{
    public class GetAllPhoneProductFeaturesDto : IDto
    {
        public IEnumerable<GetAllPhoneBrandPhoneProductFeatureDto> Brands { get; set; }
        public IEnumerable<GetAllPhoneModelPhoneProductFeatureDto> Models { get; set; }
        public IEnumerable<GetAllPhoneInternalMemoryPhoneProductFeatureDto> InternalMemories { get; set; }
        public IEnumerable<GetAllPhoneRAMPhoneProductFeatureDto> PhoneRAMs { get; set; }


    }
}