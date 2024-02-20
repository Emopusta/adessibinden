using Core.Application.Dtos;

namespace Application.Features.UserProfiles.Dtos
{
    public class GetByUserIdUserProfileRequestDto : IRequestDto
    {
        public int UserId { get; set; }
    }
}
