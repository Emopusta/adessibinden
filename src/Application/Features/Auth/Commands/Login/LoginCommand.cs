using Core.Application.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : ICommandRequest<LoggedResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
    }

    public LoginCommand(UserForLoginDto userForLoginDto)
    {
        UserForLoginDto = userForLoginDto;
    }

}
