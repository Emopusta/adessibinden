using Application.Features.UserFavouriteProducts.Queries.GetByUserId;
using AutoMapper;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() 
        {
            CreateMap<GetByUserIdUserFavouriteProductResponse, UserFavouriteProduct>().ReverseMap();
        }
    }
}
