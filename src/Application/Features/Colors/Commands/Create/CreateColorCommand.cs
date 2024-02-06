using Core.Application.Pipelines;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : ICommandRequest<CreatedColorResponse>
{
    public string Name { get; set; }
}
