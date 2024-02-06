using Application.Services.ProductService.Responses;

namespace Application.Services.ProductService;
public interface IProductService
{
  Task<DeletedProductServiceResponse> DeleteProduct(int productId, CancellationToken cancellationToken);
}
