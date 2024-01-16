using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProducts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<PhoneProduct, GetByIdDetailsPhoneProductResponse>().ReverseMap();

        }
    }
}
