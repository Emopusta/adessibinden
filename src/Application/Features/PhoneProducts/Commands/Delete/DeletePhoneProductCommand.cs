﻿using Application.Features.PhoneProducts.Dtos;
using Core.Application.CQRS;

namespace Application.Features.PhoneProducts.Commands.Delete;

public class DeletePhoneProductCommand : ICommandRequest<DeletedPhoneProductResponse>
{
    public int ProductId { get; set; }
    public DeletePhoneProductCommand(DeletePhoneProductRequestDto deletePhoneProductRequestDto)
    {
        ProductId = deletePhoneProductRequestDto.ProductId;
    }
}
