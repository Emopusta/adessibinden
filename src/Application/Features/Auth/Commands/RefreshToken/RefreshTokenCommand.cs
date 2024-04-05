using Core.Application.CQRS;

namespace Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : ICommandRequest<RefreshedTokensResponse>
{
    public string RefreshToken { get; set; }


    public RefreshTokenCommand()
    {
        RefreshToken = string.Empty;
    }

    public RefreshTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

}
