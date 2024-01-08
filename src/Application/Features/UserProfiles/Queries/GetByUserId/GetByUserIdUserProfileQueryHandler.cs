using Application.Features.UserProfiles.Rules;
using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.UserProfiles.Queries.GetByUserId
{
    public class GetByUserIdUserProfileQueryHandler : IRequestHandler<GetByUserIdUserProfileQuery, GetUserProfileResponse>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileBusinessRules _businessRules;

        public GetByUserIdUserProfileQueryHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper, UserProfileBusinessRules businessRules)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetUserProfileResponse> Handle(GetByUserIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            await _businessRules.UserProfileMustExist(request.UserId);

            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: p => p.UserId == request.UserId,
                cancellationToken: cancellationToken
                );


            var response = _mapper.Map<GetUserProfileResponse>(userProfile);

            return response;
        }
       
    }
}
