﻿using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Microsoft.AspNetCore.Http;
using Core.Application.CQRS;

namespace Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : ICommandRequestHandler<RefreshTokenCommand, RefreshedTokensResponse>
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RefreshTokenCommandHandler(IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules, IHttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _userService = userService;
        _authBusinessRules = authBusinessRules;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<RefreshedTokensResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        request.RefreshToken = RefreshTokenCookieHelper.GetRefreshTokenFromCookies(_httpContextAccessor.HttpContext);

        var refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);

        if (refreshToken!.Revoked != null && refreshToken!.ReplacedByToken != null)
            await _authService.RevokeDescendantRefreshTokens(
                refreshToken,
                ipAddress,
                reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}"
            );
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        var user = await _userService.GetAsync(predicate: u => u.Id == refreshToken.UserId, cancellationToken: cancellationToken);
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

        var newRefreshToken = await _authService.RotateRefreshToken(
            user: user!,
            refreshToken,
            ipAddress
        );
        var addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);
        await _authService.DeleteOldRefreshTokens(refreshToken.UserId);
        RefreshTokenCookieHelper.SetRefreshTokenToCookie(_httpContextAccessor.HttpContext, addedRefreshToken);

        var createdAccessToken = await _authService.CreateAccessToken(user!);

        var refreshedTokensResponse = new RefreshedTokensResponse() { AccessToken = createdAccessToken};
        return refreshedTokensResponse;
    }
}
