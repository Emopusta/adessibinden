using Application.Features.UserFavouriteProducts.Constants;
using Core.Application.GenericRepository;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;
using MediatR;

namespace Application.Features.UserFavouriteProducts.Commands.Delete
{
    public class DeleteUserFavouriteProductCommandHandler : IRequestHandler<DeleteUserFavouriteProductCommand, DeletedUserFavouriteProductResponse>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        public DeleteUserFavouriteProductCommandHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
        }

        public async Task<DeletedUserFavouriteProductResponse> Handle(DeleteUserFavouriteProductCommand request, CancellationToken cancellationToken)
        {
            var userFavouriteProductToDelete = await _userFavouriteProductRepository.GetAsync(predicate: p => (p.ProductId == request.ProductId) && (p.UserId == request.UserId));

            if (userFavouriteProductToDelete == null) throw new BusinessException(UserFavouriteProductBusinessMessages.UserFavouriteProductMustExistToDelete);

            var deletedUserFavouriteProduct = await _userFavouriteProductRepository.DeleteAsync(userFavouriteProductToDelete, permanent: true);

            var response = new DeletedUserFavouriteProductResponse()
            {
                UserId = deletedUserFavouriteProduct.UserId,
                ProductId = deletedUserFavouriteProduct.ProductId,
            };

            return response;

        }
    }
}
