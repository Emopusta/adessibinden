using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetById
{
    public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, GetUserProfileResponse>
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;

        public GetByIdUserProfileQueryHandler(IGenericRepository<UserProfile> userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<GetUserProfileResponse> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: p => p.UserId == request.UserId,
                cancellationToken: cancellationToken
                );

            //add business

            var response = _mapper.Map<GetUserProfileResponse>(userProfile);

            return response;
        }
       
    }
}
