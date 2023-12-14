using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, GetByIdColorResponse>().ReverseMap();

            CreateMap<Color, GetAllColorsListItemDto>().ReverseMap();
            CreateMap<IPaginate<Color>, GetListResponse<GetAllColorsListItemDto>>().ReverseMap();
        }
    }
}
