using Core.Application.Responses;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdatedUserProfileResponse : IResponse
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
}