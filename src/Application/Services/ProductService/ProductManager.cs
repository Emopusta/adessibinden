using Application.Features.Users.Rules;
using Application.Services.ProductService.Responses;
using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Domain.Models;

namespace Application.Services.ProductService;
public class ProductManager : IProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeletedProductServiceResponse> DeleteProduct(int productId, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository.GetAsync(p => p.Id == productId);
        var deletedProduct = await _productRepository.DeleteAsync(productToDelete);
        await _unitOfWork.SaveAsync(cancellationToken);

        return new DeletedProductServiceResponse() { ProductId = deletedProduct.Id };
    }
}
