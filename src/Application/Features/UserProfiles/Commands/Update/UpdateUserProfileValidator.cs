﻿using Application.Features.UserProfiles.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;

        public UpdateUserProfileValidator(IGenericRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;

            RuleFor(p => p.UpdateUserProfileDto.UserId).NotEmpty().MustAsync(async (userId, _) =>
            {
                return await UserProfileMustExist(userId);
            }).WithMessage(UserProfilesBusinessMessages.UserProfileMustExist);
        }



        private async Task<bool> UserProfileMustExist(int userId)
        {
            return (await _userProfileRepository.GetAsync(p => p.UserId == userId)) != null;
        }
    }
}
