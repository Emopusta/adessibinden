using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Responses;
using Domain.Models;
using MediatR;

namespace Application.Features.Products.Queries.GetByCreatorUserIdPaginated
{
    public class GetByCreatorUserIdPaginatedQueryHandler : IRequestHandler<GetByCreatorUserIdPaginatedQuery, GetListResponse<GetByCreatorUserIdPaginatedDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetByCreatorUserIdPaginatedQueryHandler(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByCreatorUserIdPaginatedDto>> Handle(GetByCreatorUserIdPaginatedQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetPaginateListAsync(
                  predicate: p => p.CreatorUserId == request.CreatorUserId,
                  index: request.PageRequest.PageIndex,
                  size: request.PageRequest.PageSize
                  );

            var result = _mapper.Map<GetListResponse<GetByCreatorUserIdPaginatedDto>>(products);

            return result;
        }
    }
}
