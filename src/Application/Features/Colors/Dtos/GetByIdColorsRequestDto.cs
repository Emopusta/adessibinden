using Core.Application.Dtos;

namespace Application.Features.Colors.Dtos;

public class GetByIdColorsRequestDto : IRequestDto
{
    public int Id { get; set; }
}
