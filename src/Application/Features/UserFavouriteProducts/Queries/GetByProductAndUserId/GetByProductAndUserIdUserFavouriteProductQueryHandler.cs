using Application.Features.UserFavouriteProducts.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId
{
    public class GetByProductAndUserIdUserFavouriteProductQueryHandler : IRequestHandler<GetByProductAndUserIdUserFavouriteProductQuery, GetByProductAndUserIdUserFavouriteProductResponse>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
        private readonly UserFavouriteProductBusinessRules _userFavouriteProductBusinessRules;

        public GetByProductAndUserIdUserFavouriteProductQueryHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository, UserFavouriteProductBusinessRules userFavouriteProductBusinessRules)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
            _userFavouriteProductBusinessRules = userFavouriteProductBusinessRules;
        }

        public async Task<GetByProductAndUserIdUserFavouriteProductResponse> Handle(GetByProductAndUserIdUserFavouriteProductQuery request, CancellationToken cancellationToken)
        {
            var userFavouriteProfile = await _userFavouriteProductRepository.GetAsync(p => (p.ProductId == request.ProductId)&&(p.UserId == request.UserId));

            await _userFavouriteProductBusinessRules.UserFavouriteProductMustExist(userFavouriteProfile);

            var response = new GetByProductAndUserIdUserFavouriteProductResponse()
            {
                ProductId = userFavouriteProfile.ProductId,
                UserId = userFavouriteProfile.UserId,
            };

            return response;
        }
    }
}
