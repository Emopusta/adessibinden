using Core.Application.Pipelines;

namespace Application.Features.CarChassisTypes.Commands.Create;

public partial class CreateCarChassisTypeCommand : ICommandRequest<CreatedCarChassisTypeResponse>
{
    public string Name{ get; set; }
}
