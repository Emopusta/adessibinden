using Application.Features.UserProfiles.Dtos;
using Core.Application.CQRS;

namespace Application.Features.UserProfiles.Commands.Create;
public class CreateUserProfileCommand : ICommandRequest<CreatedUserProfileResponse>
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }

    public CreateUserProfileCommand(CreateUserProfileRequestDto createUserProfileRequestDto)
    {
        UserId = createUserProfileRequestDto.UserId;
        FirstName = createUserProfileRequestDto.FirstName;
        LastName = createUserProfileRequestDto.LastName;
        Address = createUserProfileRequestDto.Address;
        BirthDate = createUserProfileRequestDto.BirthDate;
    }
}
