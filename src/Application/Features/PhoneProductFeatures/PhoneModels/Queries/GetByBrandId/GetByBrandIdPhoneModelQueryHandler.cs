using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId
{
    public class GetByBrandIdPhoneModelQueryHandler : IRequestHandler<GetByBrandIdPhoneModelQuery, List<GetByBrandIdPhoneModelDto>>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
        private readonly IMapper _mapper;

        public GetByBrandIdPhoneModelQueryHandler(IGenericRepository<PhoneModel> phoneModelRepository, IMapper mapper)
        {
            _phoneModelRepository = phoneModelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByBrandIdPhoneModelDto>> Handle(GetByBrandIdPhoneModelQuery request, CancellationToken cancellationToken)
        {
            var phoneModels = await _phoneModelRepository.GetListAsync(p => p.BrandId == request.BrandId);

            var mappedphoneModels = _mapper.Map<List<GetByBrandIdPhoneModelDto>>(phoneModels);

            return mappedphoneModels;
        }
    }
}
