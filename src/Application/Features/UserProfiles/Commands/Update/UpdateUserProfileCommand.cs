using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdateUserProfileCommand : ICommandRequest<UpdatedUserProfileResponse>
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public UpdateUserProfileCommand(UpdateUserProfileRequestDto createUserProfileRequestDto)
    {
        UserId = createUserProfileRequestDto.UserId;
        FirstName = createUserProfileRequestDto.FirstName;
        LastName = createUserProfileRequestDto.LastName;
        Address = createUserProfileRequestDto.Address;
        BirthDate = createUserProfileRequestDto.BirthDate;
    }
}
