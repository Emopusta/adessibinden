using Core.Application.CQRS;
using Core.Application.Dtos;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : ICommandRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }


    public RegisterCommand()
    {
        UserForRegisterDto = null!;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto)
    {
        UserForRegisterDto = userForRegisterDto;
    }

    
}
