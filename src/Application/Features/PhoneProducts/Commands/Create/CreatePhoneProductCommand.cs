using Application.Features.PhoneProducts.Dtos;
using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Commands.Create;

public class CreatePhoneProductCommand : ICommandRequest<CreatedPhoneProductResponse>
{
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

    public CreatePhoneProductCommand(CreatePhoneProductRequestDto createPhoneProductRequestDto)
    {
        ProductCategoryId = createPhoneProductRequestDto.ProductCategoryId;
        Title = createPhoneProductRequestDto.Title;
        Description = createPhoneProductRequestDto.Description;
        CreatorUserId = createPhoneProductRequestDto.CreatorUserId;
        ColorId = createPhoneProductRequestDto.ColorId;
        ModelId = createPhoneProductRequestDto.ModelId;
        InternalMemoryId = createPhoneProductRequestDto.InternalMemoryId;
        RAMId = createPhoneProductRequestDto.RAMId;
        UsageStatus = createPhoneProductRequestDto.UsageStatus;
        Price = createPhoneProductRequestDto.Price;
    }
}
