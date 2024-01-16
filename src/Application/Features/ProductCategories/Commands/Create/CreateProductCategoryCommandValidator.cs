using Application.Features.ProductCategories.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        public CreateProductCategoryCommandValidator(IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;

            RuleFor(p => p.Name).MustAsync(async (productCategoryName, _) =>
            {
                return await ProductCategoryNameCannotDuplicate(productCategoryName);
            }).WithMessage(ProductCategoryBusinessMessages.ProductCategoryNameDuplicated);

        }

        private async Task<bool> ProductCategoryNameCannotDuplicate(string productCategoryName)
        {
            var productCategory = await _productCategoryRepository.GetAsync(c => c.Name == productCategoryName);
            return productCategory == null;
        }
    }
}
