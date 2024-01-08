using Application.Features.ProductCategories.Rules;
using Application.Features.Users.Rules;
using Application.Services.ProductService.Responses;
using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Domain.Models;

namespace Application.Services.ProductService
{
    public class ProductManager : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IGenericRepository<Product> productRepository, UserBusinessRules userBusinessRules, ProductCategoryBusinessRules productCategoryBusinessRules, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _userBusinessRules = userBusinessRules;
            _productCategoryBusinessRules = productCategoryBusinessRules;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreatedProductServiceResponse> CreateProduct(int creatorUserId, int productCategoryId)
        {
            await _userBusinessRules.UserMustExistById(creatorUserId);
            await _productCategoryBusinessRules.ProductCategoryMustExistById(productCategoryId);

            Product product = new()
            {
                CreatorUserId = creatorUserId,
                ProductCategoryId = productCategoryId
            };

            Product addedProduct = await _productRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            CreatedProductServiceResponse response = new()
            {
                Id = addedProduct.Id,
                CreatorUserId = addedProduct.CreatorUserId,
                ProductCategoryId = addedProduct.ProductCategoryId
            };

            return response;
        }
    }
}
