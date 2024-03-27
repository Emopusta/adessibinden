using Core.Application.Services;

namespace Application.Services.UserFavouriteProductService;

public interface IUserFavouriteProductService : IServiceBase
{
    Task DeleteFavouritesByProduct(int productId);
}
