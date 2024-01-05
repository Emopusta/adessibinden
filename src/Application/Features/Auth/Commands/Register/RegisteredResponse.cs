using Core.Application.Responses;
using Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    
    public int UserId { get; set; }
}
