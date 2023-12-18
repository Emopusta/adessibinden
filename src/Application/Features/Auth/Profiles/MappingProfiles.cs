using Application.Features.Auth.Commands.RevokeToken;
using AutoMapper;
using Domain.Models;

namespace Application.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
    }
}
