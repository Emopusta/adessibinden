using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;
using Core.Cache.Cache;


namespace Application.Features.PhoneProducts.Commands.Update;

public class UpdatePhoneProductCommand : ICommandRequest<UpdatedPhoneProductResponse>, IEmopCache
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

    public string CacheKey { get; }

    public UpdatePhoneProductCommand(UpdatePhoneProductRequestDto updatePhoneProductRequestDto)
    {
        CacheKey = $"PhoneProductGetByIdDetails {updatePhoneProductRequestDto.ProductId}";

        ProductCategoryId = updatePhoneProductRequestDto.ProductCategoryId;
        Title = updatePhoneProductRequestDto.Title;
        Description = updatePhoneProductRequestDto.Description;
        CreatorUserId = updatePhoneProductRequestDto.CreatorUserId;
        ProductId = updatePhoneProductRequestDto.ProductId;
        ColorId = updatePhoneProductRequestDto.ColorId;
        ModelId = updatePhoneProductRequestDto.ModelId;
        InternalMemoryId = updatePhoneProductRequestDto.InternalMemoryId;
        RAMId = updatePhoneProductRequestDto.RAMId;
        UsageStatus = updatePhoneProductRequestDto.UsageStatus;
        Price = updatePhoneProductRequestDto.Price;
    }
}
