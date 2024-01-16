using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId
{
    public class GetByProductAndUserIdUserFavouriteProductQueryValidator : AbstractValidator<GetByProductAndUserIdUserFavouriteProductQuery>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        public GetByProductAndUserIdUserFavouriteProductQueryValidator(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;



            RuleFor(p => new { p.ProductId, p.UserId }).MustAsync(async (compositeKeys, _) =>
            {
                return await UserFavouriteProductMustExist(compositeKeys.UserId, compositeKeys.ProductId);
            }).WithMessage(UserFavouriteProductBusinessMessages.UserFavouriteProductMustExist);
        }

        public async Task<bool> UserFavouriteProductMustExist(int userId, int productId)
        {
            var userFavouriteProduct = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == productId) && (p.UserId == userId)); ;
            return userFavouriteProduct != null;

        }
    }
}
