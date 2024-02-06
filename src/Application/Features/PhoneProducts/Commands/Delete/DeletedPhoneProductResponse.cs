using Core.Application.Responses;

namespace Application.Features.PhoneProducts.Commands.Delete;

public class DeletedPhoneProductResponse : IResponse
{
    public int ProductId { get; set; }
}