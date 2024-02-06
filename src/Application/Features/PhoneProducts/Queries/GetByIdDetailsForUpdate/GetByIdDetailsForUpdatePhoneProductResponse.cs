using Core.Application.Responses;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;

public class GetByIdDetailsForUpdatePhoneProductResponse : IResponse
{
    public string ProductDescription { get; set; }
    public string ProductTitle { get; set; }
    public string ProductCreatorUserEmail { get; set; }
    public int ProductCreatorUserId { get; set; }
    public int ProductProductCategoryId { get; set; }
    public int ColorId { get; set; }
    public string ColorName { get; set; }
    public int ModelId { get; set; }
    public string ModelName { get; set; }
    public int ModelBrandId { get; set; }
    public string ModelBrandName { get; set; }
    public int InternalMemoryId { get; set; }
    public string InternalMemoryCapacity { get; set; }
    public int RAMId { get; set; }
    public string RAMMemory { get; set; }
    public bool UsageStatus { get; set; }
    public decimal Price { get; set; }
}