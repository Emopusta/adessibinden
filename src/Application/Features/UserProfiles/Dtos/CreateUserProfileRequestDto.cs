using Core.Application.Dtos;

namespace Application.Features.UserProfiles.Dtos
{
    public class CreateUserProfileRequestDto : IRequestDto
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
