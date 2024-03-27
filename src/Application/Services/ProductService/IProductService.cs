using Application.Services.ProductService.Responses;
using Core.Application.Services;

namespace Application.Services.ProductService;
public interface IProductService : IServiceBase
{
  Task<DeletedProductServiceResponse> DeleteProduct(int productId, CancellationToken cancellationToken);
}
