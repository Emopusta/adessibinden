using Application.Features.Products.Commands.Create;
using Application.Services.ProductService.Responses;

namespace Application.Services.ProductService
{
    public interface IProductService
    {
        Task<CreatedProductServiceResponse> CreateProduct(int creatorUserId, int productCategoryId, string description, string title);
      
    }
}
