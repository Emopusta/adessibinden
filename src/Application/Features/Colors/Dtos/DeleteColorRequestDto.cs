using Core.Application.Dtos;

namespace Application.Features.Colors.Dtos;

public class DeleteColorRequestDto : IRequestDto
{
    public int Id { get; set; }
}
