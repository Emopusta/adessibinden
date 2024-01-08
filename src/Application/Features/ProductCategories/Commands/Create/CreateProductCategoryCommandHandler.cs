using Application.Features.ProductCategories.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, CreatedProductCategoryResponse>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public CreateProductCategoryCommandHandler(IGenericRepository<ProductCategory> productCategoryRepository, ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _productCategoryRepository = productCategoryRepository;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<CreatedProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await _productCategoryBusinessRules.ProductCategoryNameCannotDuplicate(request.Name);

            ProductCategory productCategory = new()
            {
                Name = request.Name
            };

            ProductCategory addedProductCategory = await _productCategoryRepository.AddAsync(productCategory);

            CreatedProductCategoryResponse response = new()
            {
                Name = addedProductCategory.Name,
            };

            return response;
        }
    }
}
