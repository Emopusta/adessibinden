using Application.Features.ProductCategories.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.ProductCategories.Queries.GetAllList
{
    public class GetAllListProductCategoryQueryValidator : AbstractValidator<GetAllListProductCategoryQuery>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        public GetAllListProductCategoryQueryValidator(IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;

            RuleFor(p => p).MustAsync(async (_, _) =>
            {
                return await ProductCategoriesMustExist();
            }).WithMessage(ProductCategoryBusinessMessages.ProductCategoryMustExist);

        }

        private async Task<bool> ProductCategoriesMustExist()
        {
            var productCategory = await _productCategoryRepository.AnyAsync();
            return productCategory;
        }
    }
}
