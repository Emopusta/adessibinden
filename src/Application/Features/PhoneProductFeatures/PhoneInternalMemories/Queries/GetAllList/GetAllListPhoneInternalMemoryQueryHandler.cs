using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList
{
    public class GetAllListPhoneInternalMemoryQueryHandler : IRequestHandler<GetAllListPhoneInternalMemoryQuery, List<GetAllListPhoneInternalMemoryDto>>
    {
        private readonly IGenericRepository<PhoneInternalMemory> _phoneInternalMemoryRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneInternalMemoryQueryHandler(IGenericRepository<PhoneInternalMemory> phoneInternalMemoryRepository, IMapper mapper)
        {
            _phoneInternalMemoryRepository = phoneInternalMemoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListPhoneInternalMemoryDto>> Handle(GetAllListPhoneInternalMemoryQuery request, CancellationToken cancellationToken)
        {
            var phoneInternalMemories = await _phoneInternalMemoryRepository.GetListAsync();

            var mappedPhoneInternalMemories = _mapper.Map<List<GetAllListPhoneInternalMemoryDto>>(phoneInternalMemories);

            return mappedPhoneInternalMemories;
        }
    }
}
