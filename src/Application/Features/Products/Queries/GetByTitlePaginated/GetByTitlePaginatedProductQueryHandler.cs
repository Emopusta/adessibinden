using Application.Features.Products.Dtos;
using AutoMapper;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.Products.Queries.GetByTitlePaginated;

public class GetByTitlePaginatedProductQueryHandler : IQueryRequestHandler<GetByTitlePaginatedProductQuery, PaginateResponse<GetByTitlePaginatedProductDto>>
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetByTitlePaginatedProductQueryHandler(IGenericRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PaginateResponse<GetByTitlePaginatedProductDto>> Handle(GetByTitlePaginatedProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetPaginateListAsync(
            predicate: p => p.Title.Contains(request.ProductTitleToSearch),
            size: request.PageRequest.PageSize,
            index: request.PageRequest.PageIndex,
            cancellationToken: cancellationToken
            );

        var response = _mapper.Map<PaginateResponse<GetByTitlePaginatedProductDto>>(products);
        return response;
    }
}
