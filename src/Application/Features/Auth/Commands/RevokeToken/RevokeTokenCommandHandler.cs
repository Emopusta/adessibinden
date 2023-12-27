using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using AutoMapper;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Auth.Commands.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, IDataResult<RevokedTokenResponse>>
{
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;

    public RevokeTokenCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IMapper mapper)
    {
        _authService = authService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
    }

    public async Task<IDataResult<RevokedTokenResponse>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _authService.GetRefreshTokenByToken(request.Token);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken!);

        await _authService.RevokeRefreshToken(token: refreshToken!, request.IpAddress, reason: "Revoked without replacement");

        RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(refreshToken);
        return new SuccessDataResult<RevokedTokenResponse>(revokedTokenResponse, "Refresh token revoked.");
    }
}
