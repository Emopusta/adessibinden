using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;

public class GetByBrandIdPhoneModelQueryHandler : IQueryRequestHandler<GetByBrandIdPhoneModelQuery, ListResponse<GetByBrandIdPhoneModelDto>>
{
    private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
    private readonly IMapper _mapper;
    public GetByBrandIdPhoneModelQueryHandler(IGenericRepository<PhoneModel> phoneModelRepository, IMapper mapper)
    {
        _phoneModelRepository = phoneModelRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetByBrandIdPhoneModelDto>> Handle(GetByBrandIdPhoneModelQuery request, CancellationToken cancellationToken)
    {
        var phoneModels = await _phoneModelRepository.GetListAsync(p => p.BrandId == request.BrandId);
        var mappedphoneModels = _mapper.Map<ListResponse<GetByBrandIdPhoneModelDto>>(phoneModels);
        return mappedphoneModels;
    }
}
