using Application.Features.UserFavouriteProducts.Queries.GetByUserId;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() 
        {
            CreateMap<GetByUserIdUserFavouriteProductResponse, UserFavouriteProduct>().ReverseMap();
            CreateMap<IListResponse<UserFavouriteProduct>, ListResponse<GetByUserIdUserFavouriteProductResponse>>().ReverseMap();
        }
    }
}
