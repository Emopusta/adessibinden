using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.UserFavouriteProducts.Commands.Create;

public class CreateUserFavouriteProductCommandValidator : AbstractValidator<CreateUserFavouriteProductCommand>
{
    IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
    public CreateUserFavouriteProductCommandValidator(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
    {
        _userFavouriteProductRepository = userFavouriteProductRepository;

        RuleFor(p => new UserFavouriteProduct(){ ProductId = p.ProductId, UserId = p.UserId })
            .MustAsync(UserFavouriteProductCannotDuplicate).WithMessage(UserFavouriteProductBusinessMessages.UserFavouriteProductDuplicated);
    }

    public async Task<bool> UserFavouriteProductCannotDuplicate(UserFavouriteProduct favourite, CancellationToken cancellationToken)
    {
        var userFavouriteProduct = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == favourite.ProductId) && (p.UserId == favourite.UserId)); ;
        return userFavouriteProduct == null;
    }
}
