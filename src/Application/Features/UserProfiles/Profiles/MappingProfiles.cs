using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Dtos;
using Application.Features.UserProfiles.Commands.Update;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<CreateUserProfileCommand, UserProfile>().ReverseMap();
            CreateMap<CreatedUserProfileResponse, UserProfile>().ReverseMap();

            CreateMap<UpdateUserProfileCommand, UserProfile>().ReverseMap();
            CreateMap<UpdateUserProfileDto, UserProfile>().ReverseMap();
            CreateMap<UpdatedUserProfileResponse, UserProfile>().ReverseMap();

        }
    }
}
