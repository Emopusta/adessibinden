using Application.Features.Users.Rules;
using Core.Application.GenericRepository;
using Core.Persistence.Paging;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsersService;

public class UserManager : IUserService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly UserBusinessRules _userBusinessRules;

    public UserManager(IGenericRepository<User> userRepository, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>?> GetListAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _userRepository.GetPaginateListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _userRepository.AddAsync(user);
        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);
        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);
        return deletedUser;
    }
}
