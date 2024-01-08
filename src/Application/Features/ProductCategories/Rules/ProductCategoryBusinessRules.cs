using Application.Features.ProductCategories.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.ProductCategories.Rules
{
    public class ProductCategoryBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        public ProductCategoryBusinessRules(IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task ProductCategoryNameCannotDuplicate(string name)
        {
            var color = await _productCategoryRepository.GetAsync(c => c.Name == name);
            if (color != null) throw new BusinessException(ProductCategoryBusinessMessages.ProductCategoryNameDuplicated);

        }
        public async Task ProductCategoryMustExistById(int productCategoryId)
        {
            var color = await _productCategoryRepository.GetAsync(c => c.Id == productCategoryId);
            if (color == null) throw new BusinessException(ProductCategoryBusinessMessages.ProductCategoryMustExist);

        }
    }
}
