using Core.Application.Responses;
using Core.Security.JWT;

namespace Application.Features.Auth.Commands.RefreshToken;

public class RefreshedTokensResponse : IResponse
{
    public AccessToken AccessToken { get; set; }

    public RefreshedTokensResponse()
    {
        AccessToken = null!;
    }

    public RefreshedTokensResponse(AccessToken accessToken)
    {
        AccessToken = accessToken;
    }
}
