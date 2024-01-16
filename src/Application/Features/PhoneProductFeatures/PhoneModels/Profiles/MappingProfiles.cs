using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<PhoneModel, GetAllListPhoneModelDto>().ReverseMap();
            CreateMap<PhoneModel, GetByBrandIdPhoneModelDto>().ReverseMap();

        }
    }
}
