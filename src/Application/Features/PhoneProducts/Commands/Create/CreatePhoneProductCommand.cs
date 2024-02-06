using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Commands.Create;

public class CreatePhoneProductCommand : ICommandRequest<CreatedPhoneProductResponse>
{
    public CreatePhoneProductDto CreatePhoneProductDto { get; set; }
}
