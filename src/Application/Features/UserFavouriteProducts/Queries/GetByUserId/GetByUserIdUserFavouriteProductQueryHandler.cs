using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFavouriteProducts.Queries.GetByUserId
{
    public class GetByUserIdUserFavouriteProductQueryHandler : IRequestHandler<GetByUserIdUserFavouriteProductQuery, List<GetByUserIdUserFavouriteProductResponse>>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
        private readonly IMapper _mapper;

        public GetByUserIdUserFavouriteProductQueryHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository, IMapper mapper)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByUserIdUserFavouriteProductResponse>> Handle(GetByUserIdUserFavouriteProductQuery request, CancellationToken cancellationToken)
        {

            var userFavouriteProducts = await _userFavouriteProductRepository.GetListAsync(predicate: p => p.UserId == request.UserId,
                include: i => i.Include(i => i.Product)); 

            var response = _mapper.Map<List<GetByUserIdUserFavouriteProductResponse>>(userFavouriteProducts);

            return response;
        }
    }
}
