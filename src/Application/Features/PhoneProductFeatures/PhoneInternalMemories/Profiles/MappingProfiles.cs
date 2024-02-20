using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<PhoneInternalMemory, GetAllListPhoneInternalMemoryDto>().ReverseMap();
        CreateMap<IListResponse<PhoneInternalMemory>, ListResponse<GetAllListPhoneInternalMemoryDto>>().ReverseMap();
    }
}
