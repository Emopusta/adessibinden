using Core.Application.Dtos;
using Core.Application.Pipelines;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

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
