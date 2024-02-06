using Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    { 
        CreateMap<PhoneRAM, GetAllListPhoneRAMDto>().ReverseMap();
        CreateMap<IListResponse<PhoneRAM>, ListResponse<GetAllListPhoneRAMDto>>().ReverseMap();
    }
}
