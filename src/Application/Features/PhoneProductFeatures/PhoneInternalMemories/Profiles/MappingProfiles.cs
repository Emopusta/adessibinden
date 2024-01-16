using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {

            CreateMap<PhoneInternalMemory, GetAllListPhoneInternalMemoryDto>().ReverseMap();

        }
    }
}
