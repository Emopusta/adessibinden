namespace Application.Services.UserFavouriteProductService;

public interface IUserFavouriteProductService
{
    Task DeleteFavouritesByProduct(int productId);
}
