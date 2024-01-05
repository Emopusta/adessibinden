using Application.Features.Colors.Constants;
using Application.Features.UserProfiles.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Rules
{
    public class UserProfileBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<UserProfile> _repository;

        public UserProfileBusinessRules(IGenericRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public async Task UserCanOnlyHaveOneUserProfile(int userId)
        {
            var userProfile = await _repository.GetAsync(c => c.UserId == userId);
            if (userProfile != null) throw new BusinessException(UserProfilesBusinessMessages.UserHasUserProfile);

        }
    }
}
