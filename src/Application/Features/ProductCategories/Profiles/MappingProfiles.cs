using Application.Features.ProductCategories.Queries.GetAllList;
using AutoMapper;
using Domain.Models;

namespace Application.Features.ProductCategories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductCategory, GetAllListProductCategoryDto>().ReverseMap();

        }
    }
}
