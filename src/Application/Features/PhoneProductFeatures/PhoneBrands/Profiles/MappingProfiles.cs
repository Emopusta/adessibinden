using Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PhoneBrand, GetAllListPhoneBrandDto>().ReverseMap();
        CreateMap<IListResponse<PhoneBrand>, ListResponse<GetAllListPhoneBrandDto>>();
    }
}
