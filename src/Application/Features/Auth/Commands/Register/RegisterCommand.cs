using Core.Application.Dtos;
using Core.Application.Pipelines;

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
