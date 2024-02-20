using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos;

public class GetByIdDetailsForUpdatePhoneProductRequestDto : IRequestDto
{
    public int ProductId { get; set; }
}
