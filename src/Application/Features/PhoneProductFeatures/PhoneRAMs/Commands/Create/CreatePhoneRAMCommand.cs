using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;

public class CreatePhoneRAMCommand : ICommandRequest<CreatedPhoneRAMResponse>
{
    public string Memory { get; set; }
}
