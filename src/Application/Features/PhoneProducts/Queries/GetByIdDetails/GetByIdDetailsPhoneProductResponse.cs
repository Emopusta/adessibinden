using Core.Application.Responses;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductResponse : IResponse
{
    public string ProductDescription { get; set; }
    public string ProductTitle { get; set; }
    public string ProductCreatorUserEmail { get; set; }
    public int ProductProductInteractionCountCount { get; set; }
    public int ProductCreatorUserId { get; set; }
    public string ColorName { get; set; }
    public string ModelName { get; set; }
    public string ModelBrandName { get; set; }
    public string InternalMemoryCapacity { get; set; }
    public string RAMMemory { get; set; }
    public bool UsageStatus { get; set; }
    public decimal Price { get; set; }
}