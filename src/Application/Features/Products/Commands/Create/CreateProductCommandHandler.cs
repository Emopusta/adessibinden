using Application.Features.ProductCategories.Rules;
using Application.Features.Users.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public CreateProductCommandHandler(IGenericRepository<Product> productRepository, UserBusinessRules userBusinessRules, ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _productRepository = productRepository;
            _userBusinessRules = userBusinessRules;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserMustExistById(request.CreatorUserId);
            await _productCategoryBusinessRules.ProductCategoryMustExistById(request.ProductCategoryId);

            Product product = new()
            {
                CreatorUserId= request.CreatorUserId,
                ProductCategoryId = request.ProductCategoryId
            };

            Product addedProduct = await _productRepository.AddAsync(product);

            CreatedProductResponse response = new()
            {
                CreatorUserId = addedProduct.CreatorUserId,
                ProductCategoryId = addedProduct.ProductCategoryId
            };

            return response;
        }
    }
}
