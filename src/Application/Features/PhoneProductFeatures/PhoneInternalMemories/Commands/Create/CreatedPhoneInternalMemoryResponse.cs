using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Commands.Create;

public class CreatedPhoneInternalMemoryResponse : IResponse
{
    public string Capacity { get; set; }
}