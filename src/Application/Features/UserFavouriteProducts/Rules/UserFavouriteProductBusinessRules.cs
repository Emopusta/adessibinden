using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Rules
{
    public class UserFavouriteProductBusinessRules : BaseBusinessRules
    {
        IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
        public UserFavouriteProductBusinessRules(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
        }

        public async Task UserFavouriteProductCannotDuplicate(int userId, int productId)
        {
            var userFavouriteProduct = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == productId) && (p.UserId == userId)); ;
            if (userFavouriteProduct != null) throw new BusinessException(UserFavouriteProductBusinessMessages.UserFavouriteProductDuplicated);

        }
        public async Task UserFavouriteProductMustExist(UserFavouriteProduct userFavouriteProduct)
        {
            if (userFavouriteProduct == null) throw new BusinessException(UserFavouriteProductBusinessMessages.UserFavouriteProductMustExist);

        }
    }
}
