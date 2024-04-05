using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Commands.Create;

public class CreateUserFavouriteProductCommandHandler : ICommandRequestHandler<CreateUserFavouriteProductCommand, CreatedUserFavouriteProductResponse>
{
    private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

    public CreateUserFavouriteProductCommandHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
    {
        _userFavouriteProductRepository = userFavouriteProductRepository;
    }

    public async Task<CreatedUserFavouriteProductResponse> Handle(CreateUserFavouriteProductCommand request, CancellationToken cancellationToken)
    {
        var userFavouriteProduct = new UserFavouriteProduct()
        {
            ProductId = request.ProductId,
            UserId = request.UserId,
        };

        var addedUserFavouriteProduct = await _userFavouriteProductRepository.AddAsync(userFavouriteProduct);

        var response = new CreatedUserFavouriteProductResponse()
        {
            ProductId = addedUserFavouriteProduct.ProductId,
            UserId = addedUserFavouriteProduct.UserId,
        };
        return response;
    }
}
