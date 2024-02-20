using Application.Features.PhoneProductFeatures.PhoneBrands.Dtos;
using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;

public class GetAllListPhoneBrandQueryHandler : IQueryRequestHandler<GetAllListPhoneBrandQuery, ListResponse<GetAllListPhoneBrandDto>>
{
    private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
    private readonly IMapper _mapper;

    public GetAllListPhoneBrandQueryHandler(IGenericRepository<PhoneBrand> phoneBrandRepository, IMapper mapper)
    {
        _phoneBrandRepository = phoneBrandRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetAllListPhoneBrandDto>> Handle(GetAllListPhoneBrandQuery request, CancellationToken cancellationToken)
    {
        var phoneBrands = await _phoneBrandRepository.GetListAsync();
        var mappedBrandModels = _mapper.Map<ListResponse<GetAllListPhoneBrandDto>>(phoneBrands);
        return mappedBrandModels;
    }
}
