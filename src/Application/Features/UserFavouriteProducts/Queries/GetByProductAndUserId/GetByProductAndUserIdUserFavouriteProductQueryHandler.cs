using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId
{
    public class GetByProductAndUserIdUserFavouriteProductQueryHandler : IQueryRequestHandler<GetByProductAndUserIdUserFavouriteProductQuery, GetByProductAndUserIdUserFavouriteProductResponse>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        public GetByProductAndUserIdUserFavouriteProductQueryHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
        }

        public async Task<GetByProductAndUserIdUserFavouriteProductResponse> Handle(GetByProductAndUserIdUserFavouriteProductQuery request, CancellationToken cancellationToken)
        {
            var userFavouriteProfile = await _userFavouriteProductRepository.GetAsync(p => (p.ProductId == request.ProductId)&&(p.UserId == request.UserId));

            var response = new GetByProductAndUserIdUserFavouriteProductResponse()
            {
                ProductId = userFavouriteProfile.ProductId,
                UserId = userFavouriteProfile.UserId,
            };

            return response;
        }
    }
}
