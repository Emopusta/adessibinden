using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos
{
    public class GetAllPhoneRAMPhoneProductFeatureDto : IDto
    {
        public int Id { get; set; }
        public string Memory { get; set; }


    }
}