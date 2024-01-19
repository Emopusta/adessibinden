using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using AutoMapper;
using Core.Application.Pipelines;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.RevokeToken;

public class RevokeTokenCommandHandler : ICommandRequestHandler<RevokeTokenCommand, RevokedTokenResponse>
{
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RevokeTokenCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<RevokedTokenResponse> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        request.Token ??= RefreshTokenCookieHelper.GetRefreshTokenFromCookies(_httpContextAccessor.HttpContext);

        var refreshToken = await _authService.GetRefreshTokenByToken(request.Token);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken!);

        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);

        await _authService.RevokeRefreshToken(token: refreshToken!, ipAddress, reason: "Revoked without replacement");

        RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(refreshToken);
        return revokedTokenResponse;
    }
}
