using Core.Application.Pipelines;

namespace Application.Features.Auth.Commands.RevokeToken;

public class RevokeTokenCommand : ICommandRequest<RevokedTokenResponse>
{
    public string Token { get; set; }

    public RevokeTokenCommand()
    {
        Token = string.Empty;
    }

    public RevokeTokenCommand(string token)
    {
        Token = token;
    }

}

