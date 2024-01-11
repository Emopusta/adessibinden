using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails
{
    public class GetByIdDetailsPhoneProductResponse : IDto
    {
        public string ProductDescription { get; set; }

        public string ProductTitle { get; set; }
        public string ProductCreatorUserEmail { get; set; }

        public string ColorName { get; set; }

        public string ModelName { get; set; }

        public string InternalMemoryCapacity { get; set; }

        public string RAMMemory { get; set; }

        public bool UsageStatus { get; set; }

        public decimal Price { get; set; }
    }
}