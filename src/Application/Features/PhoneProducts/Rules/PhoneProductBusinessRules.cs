using Application.Features.PhoneProducts.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PhoneProducts.Rules
{
    public class PhoneProductBusinessRules : BaseBusinessRules
    {

        public Task PhoneProductMustExist(PhoneProduct phoneProduct)
        {
            if (phoneProduct == null) throw new BusinessException(PhoneProductBusinessMessages.PhoneProductMustExist);
            return Task.CompletedTask;
        }

    }
}
