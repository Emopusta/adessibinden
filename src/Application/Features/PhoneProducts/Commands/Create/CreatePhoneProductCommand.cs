using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Commands.Create
{
    public class CreatePhoneProductCommand : ICommandRequest<CreatedPhoneProductResponse>
    {
        public int ProductCategoryId { get; set; }
        public int CreatorUserId { get; set; }

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int ModelId { get; set; }

        public int InternalMemoryId { get; set; }

        public int RAMId { get; set; }

        public bool UsageStatus { get; set; }

        public decimal Price { get; set; }


    }
}
