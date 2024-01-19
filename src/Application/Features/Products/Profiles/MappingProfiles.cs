using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Models;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetByCreatorUserIdPaginatedDto>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<IPaginate<Product>, PaginateResponse<GetByCreatorUserIdPaginatedDto>>().ReverseMap();
        }
    }
}
