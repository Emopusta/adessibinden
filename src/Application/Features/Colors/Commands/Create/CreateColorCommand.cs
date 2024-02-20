using Application.Features.Colors.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : ICommandRequest<CreatedColorResponse> 
{
    public string Name { get; set; }
    public CreateColorCommand(CreateColorRequestDto createColorRequestDto)
    {
        Name = createColorRequestDto.Name;
    }
}
