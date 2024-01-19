using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.CrossCuttingConcerns.Cookies;
using Core.Utilities.Network;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Application.Services.UserProfileService;
using Core.Application.Pipelines;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : ICommandRequestHandler<RegisterCommand, RegisteredResponse>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IAuthService _authService;
    private readonly IUserProfileService _userProfileService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RegisterCommandHandler(IGenericRepository<User> userRepository, IAuthService authService, IUserProfileService userProfileService, AuthBusinessRules authBusinessRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _authService = authService;
        _userProfileService = userProfileService;
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
        await _unitOfWork.SaveAsync(cancellationToken);

        await _userProfileService.CreateDefaultUserProfile(createdUser.Id);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
        var ipAddress = IpAddressHelper.GetIpAddress(_httpContextAccessor.HttpContext);
         
        var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, ipAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RefreshTokenCookieHelper.SetRefreshTokenToCookie(_httpContextAccessor.HttpContext, addedRefreshToken);

        RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken , UserId = createdUser.Id };
        return registeredResponse;
    }
}