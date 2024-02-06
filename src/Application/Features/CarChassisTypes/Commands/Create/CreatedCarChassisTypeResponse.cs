using Core.Application.Responses;

namespace Application.Features.CarChassisTypes.Commands.Create;

public class CreatedCarChassisTypeResponse : IResponse
{
    public string Name { get; set; }
}
