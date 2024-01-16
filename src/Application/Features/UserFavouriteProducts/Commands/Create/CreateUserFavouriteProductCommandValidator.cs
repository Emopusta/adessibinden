using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserFavouriteProducts.Commands.Create
{
    public class CreateUserFavouriteProductCommandValidator : AbstractValidator<CreateUserFavouriteProductCommand>
    {
        IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        public CreateUserFavouriteProductCommandValidator(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;


            RuleFor(p => new { p.ProductId, p.UserId }).MustAsync(async (compositeKeys, _) =>
            {
                return await UserFavouriteProductCannotDuplicate(compositeKeys.UserId, compositeKeys.ProductId);
            }).WithMessage(UserFavouriteProductBusinessMessages.UserFavouriteProductDuplicated);
        }

        public async Task<bool> UserFavouriteProductCannotDuplicate(int userId, int productId)
        {
            var userFavouriteProduct = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == productId) && (p.UserId == userId)); ;
            return userFavouriteProduct == null;

        }
    }
}
