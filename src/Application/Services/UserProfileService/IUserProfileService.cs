namespace Application.Services.UserProfileService;
public interface IUserProfileService
{
    Task CreateDefaultUserProfile(int userId);
}
