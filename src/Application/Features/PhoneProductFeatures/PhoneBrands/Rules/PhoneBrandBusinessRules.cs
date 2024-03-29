﻿using Application.Features.PhoneProductFeatures.PhoneBrands.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Rules;

public class PhoneBrandBusinessRules : BaseBusinessRules
{
    private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
    public PhoneBrandBusinessRules(IGenericRepository<PhoneBrand> phoneBrandRepository)
    {
        _phoneBrandRepository = phoneBrandRepository;
    }

    public async Task PhoneBrandNameCannotDuplicate(string name)
    {
        var phoneBrand = await _phoneBrandRepository.GetAsync(c => c.Name == name);
        if (phoneBrand != null) throw new BusinessException(PhoneBrandsBusinessMessages.PhoneBrandNameDuplicated);
    }
}
