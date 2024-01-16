using Application.Features.PhoneProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails
{
    public class GetByIdDetailsPhoneProductQueryValidator : AbstractValidator<GetByIdDetailsPhoneProductQuery>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;

        public GetByIdDetailsPhoneProductQueryValidator(IGenericRepository<PhoneProduct> phoneProductRepository)
        {
            _phoneProductRepository = phoneProductRepository;


            RuleFor(p => p.ProductId).MustAsync(async (productId, _) =>
            {
                return await PhoneProductMustExist(productId);
            }).WithMessage(PhoneProductBusinessMessages.PhoneProductMustExist);
        }

        private async Task<bool> PhoneProductMustExist(int productId)
        {
            return (await _phoneProductRepository.GetAsync(p => p.ProductId == productId)) != null;
        }
    }
}
