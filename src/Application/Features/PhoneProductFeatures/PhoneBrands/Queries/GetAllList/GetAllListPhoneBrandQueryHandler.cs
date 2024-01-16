using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList
{
    public class GetAllListPhoneBrandQueryHandler : IRequestHandler<GetAllListPhoneBrandQuery, List<GetAllListPhoneBrandDto>>
    {
        private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneBrandQueryHandler(IGenericRepository<PhoneBrand> phoneBrandRepository, IMapper mapper)
        {
            _phoneBrandRepository = phoneBrandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListPhoneBrandDto>> Handle(GetAllListPhoneBrandQuery request, CancellationToken cancellationToken)
        {
            var phoneBrands = await _phoneBrandRepository.GetListAsync();

            var mappedBrandModels = _mapper.Map<List<GetAllListPhoneBrandDto>>(phoneBrands);

            return mappedBrandModels;
        }
    }
}
