using Application.Features.PhoneProductFeatures.PhoneModels.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;

public class CreatePhoneModelCommand : ICommandRequest<CreatedPhoneModelResponse>
{
    public int BrandId { get; set; }
    public string Name { get; set; }

    public CreatePhoneModelCommand(CreatePhoneModelRequestDto createPhoneModelRequestDto)
    {
        BrandId = createPhoneModelRequestDto.BrandId;
        Name = createPhoneModelRequestDto.Name;
    }
}
