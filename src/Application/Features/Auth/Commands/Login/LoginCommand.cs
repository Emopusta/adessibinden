using Core.Application.Dtos;
using Core.Application.Pipelines;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : ICommandRequest<IDataResult<LoggedResponse>>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }
    public HttpResponse Response { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
        IpAddress = string.Empty;
    }

    public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress, HttpResponse response)
    {
        UserForLoginDto = userForLoginDto;
        IpAddress = ipAddress;
        Response = response;
    }

}
