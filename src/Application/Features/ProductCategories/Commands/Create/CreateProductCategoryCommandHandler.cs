using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.ProductCategories.Commands.Create;
public class CreateProductCategoryCommandHandler : ICommandRequestHandler<CreateProductCategoryCommand, CreatedProductCategoryResponse>
{
    private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

    public CreateProductCategoryCommandHandler(IGenericRepository<ProductCategory> productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<CreatedProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {

        var productCategory = new ProductCategory()
        {
            Name = request.Name
        };

        var addedProductCategory = await _productCategoryRepository.AddAsync(productCategory);

        var response = new CreatedProductCategoryResponse()
        {
            Name = addedProductCategory.Name,
        };
        return response;
    }
}
