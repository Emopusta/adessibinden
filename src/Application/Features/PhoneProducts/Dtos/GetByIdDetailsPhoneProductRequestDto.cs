using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos;

public class GetByIdDetailsPhoneProductRequestDto : IRequestDto
{
    public int ProductId { get; set; }
}
