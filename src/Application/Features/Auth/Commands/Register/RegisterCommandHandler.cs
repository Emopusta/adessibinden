﻿using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Core.Application.GenericRepository;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(IGenericRepository<User> userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
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

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
        var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return registeredResponse;
    }
}