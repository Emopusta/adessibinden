using Application.Features.PhoneProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;

public class GetByIdDetailsForUpdatePhoneProductQueryValidator : AbstractValidator<GetByIdDetailsForUpdatePhoneProductQuery>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    public GetByIdDetailsForUpdatePhoneProductQueryValidator(IGenericRepository<PhoneProduct> phoneProductRepository)
    {
        _phoneProductRepository = phoneProductRepository;

        RuleFor(p => p.ProductId)
            .MustAsync(PhoneProductMustExist).WithMessage(PhoneProductBusinessMessages.PhoneProductMustExist);
    }

    private async Task<bool> PhoneProductMustExist(int productId, CancellationToken cancellationToken)
    {
        return (await _phoneProductRepository.GetAsync(p => p.ProductId == productId)) != null;
    }
}
