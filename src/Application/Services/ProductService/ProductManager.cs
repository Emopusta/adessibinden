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

        public async Task<CreatedProductServiceResponse> CreateProduct(int creatorUserId, int productCategoryId, string description, string title)
        {
            await _userBusinessRules.UserMustExistById(creatorUserId);
            await _productCategoryBusinessRules.ProductCategoryMustExistById(productCategoryId);

            Product product = new()
            {
                Description = description,
                Title = title,
                CreatorUserId = creatorUserId,
                ProductCategoryId = productCategoryId
            };

            Product addedProduct = await _productRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            CreatedProductServiceResponse response = new()
            {
                Id = addedProduct.Id,
                Description = addedProduct.Description,
                Title = addedProduct.Title,
                CreatorUserId = addedProduct.CreatorUserId,
                ProductCategoryId = addedProduct.ProductCategoryId
            };

            return response;
        }

        public async Task<DeletedProductServiceResponse> DeleteProduct(int productId)
        {
            var productToDelete = await _productRepository.GetAsync(p => p.Id == productId);

            var deletedProduct = await _productRepository.DeleteAsync(productToDelete);
            await _unitOfWork.SaveAsync();

            return new DeletedProductServiceResponse() { ProductId = deletedProduct.Id };
        }
    }
}
