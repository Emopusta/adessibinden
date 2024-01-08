using Application.Features.UserProfiles.Rules;
using Application.Features.Users.Rules;
using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileResponse>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserProfileCommandHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules, UserBusinessRules userBusinessRules)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
            _userProfileBusinessRules = userProfileBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedUserProfileResponse> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserMustExistById(request.UpdateUserProfileDto.UserId);
            var userProfileToUpdate = await _userProfileRepository.GetAsync(up =>  up.UserId == request.UpdateUserProfileDto.UserId);

            var mappedUserProfile = _mapper.Map(request.UpdateUserProfileDto, userProfileToUpdate);
            var updatedUserProfile = _userProfileRepository.UpdateAsync(mappedUserProfile).Result;

            var response = _mapper.Map<UpdatedUserProfileResponse>(updatedUserProfile);

            return response;
        }
    }
}
