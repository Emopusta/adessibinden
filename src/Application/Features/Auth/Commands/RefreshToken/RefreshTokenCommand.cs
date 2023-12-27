using Core.Application.Pipelines;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : ICommandRequest<IDataResult<RefreshedTokensResponse>>
{
    public string RefreshToken { get; set; }
    public string IpAddress { get; set; }
    public HttpResponse Response { get; set; }


    public RefreshTokenCommand()
    {
        RefreshToken = string.Empty;
        IpAddress = string.Empty;
    }

    public RefreshTokenCommand(string refreshToken, string ipAddress)
    {
        RefreshToken = refreshToken;
        IpAddress = ipAddress;
    }

}
