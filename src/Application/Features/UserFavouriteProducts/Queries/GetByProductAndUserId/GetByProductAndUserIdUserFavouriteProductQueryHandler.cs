using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;

public class GetByProductAndUserIdUserFavouriteProductQueryHandler : IQueryRequestHandler<GetByProductAndUserIdUserFavouriteProductQuery, GetByProductAndUserIdUserFavouriteProductResponse>
{
    private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
    private readonly IMapper _mapper;

    public GetByProductAndUserIdUserFavouriteProductQueryHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository, IMapper mapper)
    {
        _userFavouriteProductRepository = userFavouriteProductRepository;
        _mapper = mapper;
    }

    public async Task<GetByProductAndUserIdUserFavouriteProductResponse> Handle(GetByProductAndUserIdUserFavouriteProductQuery request, CancellationToken cancellationToken)
    {
        var userFavouriteProfile = await _userFavouriteProductRepository.GetAsync(p => (p.ProductId == request.ProductId)&&(p.UserId == request.UserId));
        var response = _mapper.Map<GetByProductAndUserIdUserFavouriteProductResponse>(userFavouriteProfile);
        return response;
    }
}
