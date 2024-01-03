using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Security.JWT;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
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
        User? user = await _userService.GetAsync(
            predicate: u => u.Email == request.UserForLoginDto.Email,
            cancellationToken: cancellationToken
        );
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user!.Id, request.UserForLoginDto.Password);

        LoggedResponse loggedResponse = new();

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);
        var createdRefreshToken = await _authService.CreateRefreshToken(user, ipAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        await _authService.DeleteOldRefreshTokens(user.Id);

        loggedResponse.AccessToken = createdAccessToken;
        RefreshTokenCookieHelper.SetRefreshTokenToCookie(_httpContextAccessor.HttpContext, addedRefreshToken);

        return loggedResponse;
    }

    
}
