using Core.Application.GenericRepository;
using Domain.Models;

namespace Application.Services.UserProfileService;
public class UserProfileManager : IUserProfileService
{
    private readonly IGenericRepository<UserProfile>  _userProfileRepository;

    public UserProfileManager(IGenericRepository<UserProfile> userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task CreateDefaultUserProfile(int userId)
    {
        var userProfile = new UserProfile() { UserId = userId };
        await _userProfileRepository.AddAsync(userProfile);
    }
}
