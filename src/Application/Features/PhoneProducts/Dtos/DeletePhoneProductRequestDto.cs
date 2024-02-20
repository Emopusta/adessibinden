using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos;

public class DeletePhoneProductRequestDto : IRequestDto
{
    public int ProductId { get; set; }
}
