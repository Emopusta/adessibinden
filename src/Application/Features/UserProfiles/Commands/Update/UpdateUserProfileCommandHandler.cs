using Application.Features.Users.Rules;
using AutoMapper;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Domain.Models;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdateUserProfileCommandHandler : ICommandRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileResponse>
{
    private readonly IGenericRepository<UserProfile> _userProfileRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public UpdateUserProfileCommandHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userProfileRepository = userProfileRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<UpdatedUserProfileResponse> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserMustExistById(request.UserId);

        var userProfileToUpdate = await _userProfileRepository.GetAsync(up =>  up.UserId == request.UserId);
        var mappedUserProfile = _mapper.Map(request, userProfileToUpdate);
        var updatedUserProfile = _userProfileRepository.UpdateAsync(mappedUserProfile).Result;

        var response = _mapper.Map<UpdatedUserProfileResponse>(updatedUserProfile);
        return response;
    }
}
