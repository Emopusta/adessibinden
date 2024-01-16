using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.ProductCategories.Queries.GetAllList
{
    public class GetAllListProductCategoryQueryHandler : IRequestHandler<GetAllListProductCategoryQuery, List<GetAllListProductCategoryDto>>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllListProductCategoryQueryHandler(IGenericRepository<ProductCategory> productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListProductCategoryDto>> Handle(GetAllListProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategories = await _productCategoryRepository.GetListAsync();

            var mappedProductCategories = _mapper.Map<List<GetAllListProductCategoryDto>>(productCategories);

            return mappedProductCategories;
        }
    }
}
