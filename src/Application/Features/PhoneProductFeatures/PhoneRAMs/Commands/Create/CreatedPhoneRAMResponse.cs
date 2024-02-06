using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;
public class CreatedPhoneRAMResponse : IResponse
{
    public string Memory { get; set; }
}