using Core.Application.Dtos;

namespace Application.Features.Colors.Dtos;

public class CreateColorRequestDto : IRequestDto
{
    public string Name { get; set; }
}
