using Core.Application.Responses;

namespace Application.Features.PhoneProducts.Commands.Update
{
    public class UpdatedPhoneProductResponse : IResponse
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserId { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int InternalMemoryId { get; set; }
        public int RAMId { get; set; }
        public bool UsageStatus { get; set; }
        public decimal Price { get; set; }
    }
}