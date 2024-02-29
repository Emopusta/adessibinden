using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Queries.GetTenMostExpensive;

public class GetTenMostExpensivePhoneProductListItemDto : IDto
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public int InternalMemoryId { get; set; }
    public int RAMId { get; set; }
    public bool UsageStatus { get; set; }
    public decimal Price { get; set; }
}