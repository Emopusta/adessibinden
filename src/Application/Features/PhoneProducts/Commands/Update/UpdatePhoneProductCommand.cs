using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Commands.Update;

public class UpdatePhoneProductCommand : ICommandRequest<UpdatedPhoneProductResponse>
{
    public UpdatePhoneProductDto UpdatePhoneProductDto { get; set; }
}
