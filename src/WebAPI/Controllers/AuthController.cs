using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Dtos;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{

    [HttpPost("Login")]
    public async Task<IDataResult<LoggedResponse>> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        var loginCommand = new LoginCommand() { UserForLoginDto = userForLoginDto};
        var result = await Mediator.Send(loginCommand);
        return ReturnResult(result);
    }

    [HttpPost("Register")]
    public async Task<IDataResult<RegisteredResponse>> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var registerCommand = new RegisterCommand() { UserForRegisterDto = userForRegisterDto};
        var result = await Mediator.Send(registerCommand);
        return ReturnResult(result);

    }

    [HttpGet("RefreshToken")]
    public async Task<IDataResult<RefreshedTokensResponse>> RefreshToken()
    {
        var refreshTokenCommand = new RefreshTokenCommand();
        var result = await Mediator.Send(refreshTokenCommand);
        return ReturnResult(result);

    }

    [HttpPut("RevokeToken")]
    public async Task<IDataResult<RevokedTokenResponse>> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken)
    {
        var revokeTokenCommand = new RevokeTokenCommand() { Token = refreshToken };
        var result = await Mediator.Send(revokeTokenCommand);
        return ReturnResult(result);

    }

}
