using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Models;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, GetByIdColorResponse>().ReverseMap();

            CreateMap<Color, GetAllColorsListItemDto>().ReverseMap();
            CreateMap<IPaginate<Color>, PaginateResponse<GetAllColorsListItemDto>>().ReverseMap();
        }
    }
}
