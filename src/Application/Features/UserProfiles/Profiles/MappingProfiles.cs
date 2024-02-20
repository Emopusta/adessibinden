using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetByUserId;
using AutoMapper;
using Domain.Models;

namespace Application.Features.UserProfiles.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserProfileCommand, UserProfile>().ReverseMap();
        CreateMap<CreatedUserProfileResponse, UserProfile>().ReverseMap();

        CreateMap<UpdateUserProfileCommand, UserProfile>().ReverseMap();
        CreateMap<UpdatedUserProfileResponse, UserProfile>().ReverseMap();

        CreateMap<GetUserProfileResponse, UserProfile>().ReverseMap();
    }
}
