using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.ProductCategories.Queries.GetAllList;

public class GetAllListProductCategoryQueryHandler : IQueryRequestHandler<GetAllListProductCategoryQuery, ListResponse<GetAllListProductCategoryDto>>
{
    private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllListProductCategoryQueryHandler(IGenericRepository<ProductCategory> productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetAllListProductCategoryDto>> Handle(GetAllListProductCategoryQuery request, CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetListAsync();
        var mappedProductCategories = _mapper.Map<ListResponse<GetAllListProductCategoryDto>>(productCategories);
        return mappedProductCategories;
    }
}
