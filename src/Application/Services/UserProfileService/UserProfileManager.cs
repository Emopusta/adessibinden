using Core.Application.GenericRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserProfileService
{
    public class UserProfileManager : IUserProfileService
    {
        private readonly IGenericRepository<UserProfile>  _repository;

        public UserProfileManager(IGenericRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public async Task CreateDefaultUserProfile(int userId)
        {
            var userProfile = new UserProfile() { UserId = userId };
            await _repository.AddAsync(userProfile);
        }
    }
}
