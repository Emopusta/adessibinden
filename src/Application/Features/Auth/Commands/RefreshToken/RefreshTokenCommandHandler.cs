using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Security.JWT;
using Core.Utilities.Cookies;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, IDataResult<RefreshedTokensResponse>>
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RefreshTokenCommandHandler(IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules)
    {
        _authService = authService;
        _userService = userService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<IDataResult<RefreshedTokensResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

        if (refreshToken!.Revoked != null)
            await _authService.RevokeDescendantRefreshTokens(
                refreshToken,
                request.IpAddress,
                reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}"
            );
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        User? user = await _userService.GetAsync(predicate: u => u.Id == refreshToken.UserId, cancellationToken: cancellationToken);
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

        Domain.Models.RefreshToken newRefreshToken = await _authService.RotateRefreshToken(
            user: user!,
            refreshToken,
            request.IpAddress
        );
        Domain.Models.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);
        await _authService.DeleteOldRefreshTokens(refreshToken.UserId);
        RefreshTokenCookieHelper.SetRefreshTokenToCookie(request.Response, addedRefreshToken);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user!);

        RefreshedTokensResponse refreshedTokensResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return new SuccessDataResult<RefreshedTokensResponse>(refreshedTokensResponse, "Tokens Refreshed.");
    }
}
