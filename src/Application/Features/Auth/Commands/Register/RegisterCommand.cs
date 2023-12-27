using Core.Application.Dtos;
using Core.Application.Pipelines;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : ICommandRequest<IDataResult<RegisteredResponse>>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }
    public HttpResponse Response { get; set; }


    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    
}
