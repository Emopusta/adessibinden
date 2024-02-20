using Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create;

public class CreatePhoneBrandCommand : ICommandRequest<CreatedPhoneBrandResponse>
{
    public string Name { get; set; }

    public CreatePhoneBrandCommand(CreatePhoneBrandRequestDto phoneBrandCreateRequestDto)
    {
        Name = phoneBrandCreateRequestDto.Name;
    }
}
