using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Microsoft.AspNetCore.Http;
using Core.Application.CQRS;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : ICommandRequestHandler<LoginCommand, LoggedResponse>
{
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginCommandHandler(AuthBusinessRules authBusinessRules, IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _authBusinessRules = authBusinessRules;
        _authService = authService;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetAsync(
            predicate: u => u.Email == request.UserForLoginDto.Email,
            cancellationToken: cancellationToken
        );
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user!.Id, request.UserForLoginDto.Password);

        LoggedResponse loggedResponse = new();

        var createdAccessToken = await _authService.CreateAccessToken(user);

        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);
        var createdRefreshToken = await _authService.CreateRefreshToken(user, ipAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        await _authService.DeleteOldRefreshTokens(user.Id);

        loggedResponse.AccessToken = createdAccessToken;
        RefreshTokenCookieHelper.SetRefreshTokenToCookie(_httpContextAccessor.HttpContext, addedRefreshToken);

        return loggedResponse;
    }

    
}
