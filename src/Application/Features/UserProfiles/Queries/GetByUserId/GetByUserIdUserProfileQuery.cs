using Core.Application.Pipelines;

namespace Application.Features.UserProfiles.Queries.GetByUserId
{
    public class GetByUserIdUserProfileQuery : IQueryRequest<GetUserProfileResponse>
    {
        public int UserId { get; set; }
    }
}
