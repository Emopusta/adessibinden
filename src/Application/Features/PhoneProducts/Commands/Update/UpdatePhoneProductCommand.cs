﻿using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;
using Core.Cache.Cache;


namespace Application.Features.PhoneProducts.Commands.Update;

public class UpdatePhoneProductCommand : ICommandRequest<UpdatedPhoneProductResponse>, IEmopCacheRemove
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

    public string CacheKey { get; init; }

    public UpdatePhoneProductCommand(UpdatePhoneProductRequestDto updatePhoneProductRequestDto)
    {
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

        CacheKey = $"GetByIdDetailsPhoneProductQuery {updatePhoneProductRequestDto.ProductId}";
    }
}
