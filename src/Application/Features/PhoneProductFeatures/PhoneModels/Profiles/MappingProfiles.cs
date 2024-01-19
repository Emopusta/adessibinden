using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<PhoneModel, GetAllListPhoneModelDto>().ReverseMap();
            CreateMap<IListResponse<PhoneModel>, ListResponse<GetAllListPhoneModelDto>>().ReverseMap();

            CreateMap<PhoneModel, GetByBrandIdPhoneModelDto>().ReverseMap();
            CreateMap<IListResponse<PhoneModel>, ListResponse<GetByBrandIdPhoneModelDto>>().ReverseMap();

        }
    }
}
