using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList
{
    public class GetAllListPhoneModelDto : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
    }
}