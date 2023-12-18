using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Security.JWT;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
{
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public LoginCommandHandler(
        IUserService userService,
        IAuthService authService,
        AuthBusinessRules authBusinessRules
    )
    {
        _userService = userService;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
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

        var createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        await _authService.DeleteOldRefreshTokens(user.Id);

        loggedResponse.AccessToken = createdAccessToken;
        loggedResponse.RefreshToken = addedRefreshToken;
        return loggedResponse;
    }
}
