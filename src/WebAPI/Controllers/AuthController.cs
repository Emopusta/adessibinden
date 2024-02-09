using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Dtos;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("Login")]
    public async Task<IDataResult<LoggedResponse>> Login([FromBody] UserForLoginDto userForLoginDto, CancellationToken cancellationToken)
    {
        var loginCommand = new LoginCommand() { UserForLoginDto = userForLoginDto };
        var result = await Mediator.Send(loginCommand, cancellationToken);
        return ReturnResult(result);
    }

    [Authorize]
    [HttpGet("Logout")]
    public async Task<IDataResult<LoggedOutResponse>> Logout(CancellationToken cancellationToken)
    {
        var logoutCommand = new LogoutCommand();
        var result = await Mediator.Send(logoutCommand, cancellationToken);
        return ReturnResult(result);
    }

    [HttpPost("Register")]
    public async Task<IDataResult<RegisteredResponse>> Register([FromBody] UserForRegisterDto userForRegisterDto, CancellationToken cancellationToken)
    {
        var registerCommand = new RegisterCommand() { UserForRegisterDto = userForRegisterDto};
        var result = await Mediator.Send(registerCommand, cancellationToken);
        return ReturnResult(result);
    }

    [HttpGet("RefreshToken")]
    public async Task<IDataResult<RefreshedTokensResponse>> RefreshToken(CancellationToken cancellationToken)
    {
        var refreshTokenCommand = new RefreshTokenCommand();
        var result = await Mediator.Send(refreshTokenCommand, cancellationToken);
        return ReturnResult(result);
    }

    [HttpPut("RevokeToken")]
    public async Task<IDataResult<RevokedTokenResponse>> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken, CancellationToken cancellationToken)
    {
        var revokeTokenCommand = new RevokeTokenCommand() { Token = refreshToken };
        var result = await Mediator.Send(revokeTokenCommand, cancellationToken);
        return ReturnResult(result);
    }

}
