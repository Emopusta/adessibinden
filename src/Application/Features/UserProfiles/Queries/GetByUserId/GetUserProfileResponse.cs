namespace Application.Features.UserProfiles.Queries.GetByUserId
{
    public class GetUserProfileResponse
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}