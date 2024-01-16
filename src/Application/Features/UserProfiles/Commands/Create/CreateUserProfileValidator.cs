using Application.Features.UserProfiles.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Create
{
    public class CreateUserProfileValidator : AbstractValidator<CreateUserProfileCommand>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;

        public CreateUserProfileValidator(IGenericRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;

            RuleFor(p => p.UserId).NotEmpty().MustAsync(async (userId, _) =>
            {
                return await UserCanOnlyHaveOneUserProfile(userId);
            }).WithMessage(UserProfilesBusinessMessages.UserHasUserProfile);
        }

        private async Task<bool> UserCanOnlyHaveOneUserProfile(int userId)
        {
            return (await _userProfileRepository.GetAsync(p => p.UserId == userId)) == null;
        }
    }
}
