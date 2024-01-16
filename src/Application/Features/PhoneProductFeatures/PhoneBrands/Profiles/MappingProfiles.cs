using Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
    
            CreateMap<PhoneBrand, GetAllListPhoneBrandDto>().ReverseMap();   

        }
    }
}
