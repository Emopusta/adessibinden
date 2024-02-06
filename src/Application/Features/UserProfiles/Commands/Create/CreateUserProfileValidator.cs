using Application.Features.UserProfiles.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Create;

public class CreateUserProfileValidator : AbstractValidator<CreateUserProfileCommand>
{
    private readonly IGenericRepository<UserProfile> _userProfileRepository;

    public CreateUserProfileValidator(IGenericRepository<UserProfile> userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;

        RuleFor(p => p.UserId)
            .NotEmpty()
            .MustAsync(UserCanOnlyHaveOneUserProfile).WithMessage(UserProfilesBusinessMessages.UserHasUserProfile);
    }

    private async Task<bool> UserCanOnlyHaveOneUserProfile(int userId, CancellationToken cancellationToken)
    {
        return (await _userProfileRepository.GetAsync(p => p.UserId == userId)) == null;
    }
}
