using Core.Application.Responses;

namespace Application.Features.Auth.Commands.Logout;

public class LoggedOutResponse : IResponse
{
    public string Message { get; set; }
}
