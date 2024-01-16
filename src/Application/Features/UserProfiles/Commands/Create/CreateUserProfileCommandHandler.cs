﻿using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Create
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileResponse>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;

        public CreateUserProfileCommandHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserProfileResponse> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UserProfile>(request);

            var addedUserProfile = await _userProfileRepository.AddAsync(userProfile);

            var response = _mapper.Map<CreatedUserProfileResponse>(addedUserProfile);

            return response;
        }
    }
}
