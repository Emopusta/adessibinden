using Application.Features.ProductCategories.Queries.GetAllList;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Listing;
using Domain.Models;

namespace Application.Features.ProductCategories.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductCategory, GetAllListProductCategoryDto>().ReverseMap();
        CreateMap<IListResponse<ProductCategory>, ListResponse<GetAllListProductCategoryDto>>().ReverseMap();
    }
}
