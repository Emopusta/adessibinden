using Application.Features.Products.Dtos;
using AutoMapper;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.Products.Queries.GetAllPaginated;

public class GetAllPaginatedProductQueryHandler : IQueryRequestHandler<GetAllPaginatedProductQuery, PaginateResponse<GetAllPaginatedProductDto>>
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    public GetAllPaginatedProductQueryHandler(IGenericRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PaginateResponse<GetAllPaginatedProductDto>> Handle(GetAllPaginatedProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetPaginateListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );

        var response = _mapper.Map<PaginateResponse<GetAllPaginatedProductDto>>(products);
        return response;
    }
}
