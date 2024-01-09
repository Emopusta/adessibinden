using Application.Features.PhoneProducts.Dtos;
using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetAllPhoneProductFeatures
{
    public class GetAllPhoneProductFeaturesQueryHandler : IRequestHandler<GetAllPhoneProductFeaturesQuery, GetAllPhoneProductFeaturesDto>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
        private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;
        private readonly IMapper _mapper;

        public GetAllPhoneProductFeaturesQueryHandler(IGenericRepository<PhoneModel> phoneModelRepository, IGenericRepository<PhoneBrand> phoneBrandRepository, IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository, IGenericRepository<PhoneRAM> phoneRAMRepository, IMapper mapper)
        {
            _phoneModelRepository = phoneModelRepository;
            _phoneBrandRepository = phoneBrandRepository;
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;
            _phoneRAMRepository = phoneRAMRepository;
            _mapper = mapper;
        }

        public async Task<GetAllPhoneProductFeaturesDto> Handle(GetAllPhoneProductFeaturesQuery request, CancellationToken cancellationToken)
        {

            var phoneBrands = await _phoneBrandRepository.GetListAsync();
            var phoneModels = await _phoneModelRepository.GetListAsync(include: i => i.Include(p => p.Brand));
            var phoneInternalMemories = await _phoneInternalMemoryRepository.GetListAsync();
            var phoneRAMs = await _phoneRAMRepository.GetListAsync();

            var mappedBrandModels = _mapper.Map<List<GetAllPhoneBrandPhoneProductFeatureDto>>(phoneBrands);
            var mappedPhoneModels = _mapper.Map<List<GetAllPhoneModelPhoneProductFeatureDto>>(phoneModels);
            var mappedphoneInternalMemories = _mapper.Map<List<GetAllPhoneInternalMemoryPhoneProductFeatureDto>>(phoneInternalMemories);
            var mappedPhoneRAMs = _mapper.Map<List<GetAllPhoneRAMPhoneProductFeatureDto>>(phoneRAMs);

            var allMappedPhoneProductFeatures = new GetAllPhoneProductFeaturesDto();

            _mapper.Map(mappedBrandModels, allMappedPhoneProductFeatures);
            _mapper.Map(mappedPhoneModels, allMappedPhoneProductFeatures);
            _mapper.Map(mappedphoneInternalMemories, allMappedPhoneProductFeatures);
            _mapper.Map(mappedPhoneRAMs, allMappedPhoneProductFeatures);


            return allMappedPhoneProductFeatures;

        }
    }
}
