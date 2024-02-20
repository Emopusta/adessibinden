using Application.Features.UserProfiles.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.UserProfiles.Queries.GetByUserId;

public class GetByUserIdUserProfileQuery : IQueryRequest<GetUserProfileResponse>
{
    public int UserId { get; set; }

    public GetByUserIdUserProfileQuery(GetByUserIdUserProfileRequestDto getByUserIdUserProfileRequestDto)
    {
        UserId = getByUserIdUserProfileRequestDto.UserId;
    }
}
