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

        public GetByUserIdUserProfileQueryHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<GetUserProfileResponse> Handle(GetByUserIdUserProfileQuery request, CancellationToken cancellationToken)
        {

            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: p => p.UserId == request.UserId,
                cancellationToken: cancellationToken
                );


            var response = _mapper.Map<GetUserProfileResponse>(userProfile);

            return response;
        }
       
    }
}
