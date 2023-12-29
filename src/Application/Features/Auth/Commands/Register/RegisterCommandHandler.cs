using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Cookies;
using Core.Utilities.Network;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RegisterCommandHandler(IGenericRepository<User> userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

        HashingHelper.CreatePasswordHash(
            request.UserForRegisterDto.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User newUser =
            new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
        User createdUser = await _userRepository.AddAsync(newUser);
        await _unitOfWork.SaveAsync();

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);

        var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, ipAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RefreshTokenCookieHelper.SetRefreshTokenToCookie(_httpContextAccessor.HttpContext, addedRefreshToken);

        RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken };
        return registeredResponse;
    }
}