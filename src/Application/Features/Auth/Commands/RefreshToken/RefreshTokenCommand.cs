using Core.Application.Pipelines;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

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
