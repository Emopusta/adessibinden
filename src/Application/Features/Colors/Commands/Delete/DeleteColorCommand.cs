using Application.Features.Colors.Dtos;
using Core.Application.CQRS;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand : ICommandRequest<DeletedColorResponse>
{
    public int Id { get; set; }
    public DeleteColorCommand(DeleteColorRequestDto deleteColorRequestDto)
    {
        Id = deleteColorRequestDto.Id;
    }
}
