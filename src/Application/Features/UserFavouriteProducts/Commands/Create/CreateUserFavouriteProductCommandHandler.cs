using Application.Features.UserFavouriteProducts.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.UserFavouriteProducts.Commands.Create
{
    public class CreateUserFavouriteProductCommandHandler : IRequestHandler<CreateUserFavouriteProductCommand, CreatedUserFavouriteProductResponse>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
        private readonly UserFavouriteProductBusinessRules _userFavouriteProductBusinessRules;

        public CreateUserFavouriteProductCommandHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository, UserFavouriteProductBusinessRules userFavouriteProductBusinessRules)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
            _userFavouriteProductBusinessRules = userFavouriteProductBusinessRules;
        }

        public async Task<CreatedUserFavouriteProductResponse> Handle(CreateUserFavouriteProductCommand request, CancellationToken cancellationToken)
        {
            var userFavouriteProduct = new UserFavouriteProduct()
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
            };

            await _userFavouriteProductBusinessRules.UserFavouriteProductCannotDuplicate(userFavouriteProduct.UserId, userFavouriteProduct.ProductId);

            var addedUserFavouriteProduct = await _userFavouriteProductRepository.AddAsync(userFavouriteProduct);

            var response = new CreatedUserFavouriteProductResponse()
            {
                ProductId = addedUserFavouriteProduct.ProductId,
                UserId = addedUserFavouriteProduct.UserId,
            };

            return response;
        }
    }
}
