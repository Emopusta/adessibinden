using Core.Application.CQRS;
using Core.Application.Dtos;

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
