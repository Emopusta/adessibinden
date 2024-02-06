using Core.Application.Responses;

namespace Application.Features.Colors.Commands.Create;

public class CreatedColorResponse : IResponse
{
    public string Name { get; set; }
}
