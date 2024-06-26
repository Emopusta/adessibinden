﻿using Application.Features.PhoneProductFeatures.PhoneRAMs.Dtos;
using Core.Application.CQRS;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Commands.Create;

public class CreatePhoneRAMCommand : ICommandRequest<CreatedPhoneRAMResponse>
{
    public string Memory { get; set; }

    public CreatePhoneRAMCommand(CreatePhoneRAMRequestDto createPhoneRAMRequestDto)
    {
        Memory = createPhoneRAMRequestDto.Memory;
    }
}
