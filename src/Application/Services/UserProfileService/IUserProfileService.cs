using Core.Application.Services;

namespace Application.Services.UserProfileService;
public interface IUserProfileService : IServiceBase
{
    Task CreateDefaultUserProfile(int userId);
}
