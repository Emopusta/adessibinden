using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Commands.Delete
{
    public class DeletePhoneProductCommand : ICommandRequest<DeletedPhoneProductResponse>
    {
        public int ProductId { get; set; }

    }
}
