using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Dtos
{
    public class GetAllPhoneInternalMemoryPhoneProductFeatureDto : IDto
    {
        public int Id { get; set; }
        public string Capacity { get; set; }

    }
}