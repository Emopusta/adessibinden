using Application.Features.Products.Queries.GetAllPaginated;
using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
using Application.Features.Products.Queries.GetByTitlePaginated;
using AutoMapper;
using Core.Application.Responses;
using Core.DataAccess.Paging;
using Domain.Models;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, GetByCreatorUserIdPaginatedDto>()
            .ForMember(p => p.ProductId, opt => opt.MapFrom(src => src.Id));

        CreateMap<IPaginate<Product>, PaginateResponse<GetByCreatorUserIdPaginatedDto>>().ReverseMap();

        CreateMap<Product, GetAllPaginatedProductDto>().ReverseMap();
        CreateMap<IPaginate<Product>, PaginateResponse<GetAllPaginatedProductDto>>().ReverseMap();
        
        CreateMap<Product, GetByTitlePaginatedProductDto>().ReverseMap();
        CreateMap<IPaginate<Product>, PaginateResponse<GetByTitlePaginatedProductDto>>().ReverseMap();
    }
}
