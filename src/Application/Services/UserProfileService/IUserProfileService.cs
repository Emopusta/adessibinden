using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserProfileService
{
    public interface IUserProfileService
    {
        Task CreateDefaultUserProfile(int userId);
    }
}
