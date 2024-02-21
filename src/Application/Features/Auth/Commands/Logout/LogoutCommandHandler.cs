using Application.Services.AuthService;
using Core.Application.Pipelines;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.Logout;

public class LogoutCommandHandler : ICommandRequestHandler<LogoutCommand, LoggedOutResponse>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IAuthService _authService;
    
    public LogoutCommandHandler(IHttpContextAccessor contextAccessor, IAuthService authService)
    {
        _contextAccessor = contextAccessor;
        _authService = authService;
    }

    public async Task<LoggedOutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {

        var token = RefreshTokenCookieHelper.GetRefreshTokenFromCookies(_contextAccessor.HttpContext);
        
        var refreshToken = await _authService.GetRefreshTokenByToken(token);
        var ipAddress = IpAddressHelper.GetIpAddress(_contextAccessor.HttpContext);

        await _authService.RevokeRefreshToken(refreshToken, ipAddress, "Logging out");

        RefreshTokenCookieHelper.DeleteRefreshTokenFromCookies(_contextAccessor.HttpContext);

        var result = new LoggedOutResponse()
        {
            Message = "Logged Out"
        };

        return result;

    }
}
