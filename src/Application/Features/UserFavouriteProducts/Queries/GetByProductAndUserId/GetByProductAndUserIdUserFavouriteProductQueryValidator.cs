using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId
{
    public class GetByProductAndUserIdUserFavouriteProductQueryValidator : AbstractValidator<GetByProductAndUserIdUserFavouriteProductQuery>
    {
        //private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        //public GetByProductAndUserIdUserFavouriteProductQueryValidator(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        //{
        //    _userFavouriteProductRepository = userFavouriteProductRepository;

        //    RuleFor(p => new UserFavouriteProduct (){ ProductId = p.ProductId, UserId = p.UserId })
        //        .MustAsync(UserFavouriteProductMustExist).WithMessage(UserFavouriteProductBusinessMessages.UserFavouriteProductMustExist);
        //}

        //public async Task<bool> UserFavouriteProductMustExist(UserFavouriteProduct favourite, CancellationToken cancellationToken)
        //{
        //    var userFavouriteProduct = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == favourite.ProductId) && (p.UserId == favourite.UserId)); ;
        //    return userFavouriteProduct != null;

        //}
    }
}
