using Core.Application.CQRS;

namespace Application.Features.Auth.Commands.Logout;

public class LogoutCommand : ICommandRequest<LoggedOutResponse>
{

}
