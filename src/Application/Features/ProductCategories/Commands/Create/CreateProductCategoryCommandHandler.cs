using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, CreatedProductCategoryResponse>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        public CreateProductCategoryCommandHandler(IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<CreatedProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {

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
