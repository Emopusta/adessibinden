using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;

public class CreatePhoneModelCommand : ICommandRequest<CreatedPhoneModelResponse>
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
