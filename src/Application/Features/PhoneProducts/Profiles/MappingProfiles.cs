using Application.Features.PhoneProducts.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProducts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<PhoneModel, GetAllPhoneModelPhoneProductFeatureDto>().ReverseMap();
            CreateMap<PhoneBrand, GetAllPhoneBrandPhoneProductFeatureDto>().ReverseMap();
            CreateMap<PhoneInternalMemory, GetAllPhoneInternalMemoryPhoneProductFeatureDto>().ReverseMap();
            CreateMap<PhoneRAM, GetAllPhoneRAMPhoneProductFeatureDto>().ReverseMap();

            CreateMap<List<GetAllPhoneBrandPhoneProductFeatureDto>, GetAllPhoneProductFeaturesDto>().ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src));
            CreateMap<List<GetAllPhoneModelPhoneProductFeatureDto>, GetAllPhoneProductFeaturesDto>().ForMember(dest => dest.Models, opt => opt.MapFrom(src => src));
            CreateMap<List<GetAllPhoneInternalMemoryPhoneProductFeatureDto>, GetAllPhoneProductFeaturesDto>().ForMember(dest => dest.InternalMemories, opt => opt.MapFrom(src => src));
            CreateMap<List<GetAllPhoneRAMPhoneProductFeatureDto>, GetAllPhoneProductFeaturesDto>().ForMember(dest => dest.PhoneRAMs, opt => opt.MapFrom(src => src));

        }
    }
}
