using Core.Application.Dtos;

namespace Application.Features.PhoneProducts.Commands.Update;

public class UpdatePhoneProductDto : IDto
{
    public int ProductCategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreatorUserId { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public int InternalMemoryId { get; set; }
    public int RAMId { get; set; }
    public bool UsageStatus { get; set; }
    public decimal Price { get; set; }
}
