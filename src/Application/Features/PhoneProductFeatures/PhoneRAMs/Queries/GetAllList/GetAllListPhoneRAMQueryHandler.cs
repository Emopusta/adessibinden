using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList
{
    public class GetAllListPhoneRAMQueryHandler : IRequestHandler<GetAllListPhoneRAMQuery, List<GetAllListPhoneRAMDto>>
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneRAMQueryHandler(IGenericRepository<PhoneRAM> phoneRAMRepository, IMapper mapper)
        {
            _phoneRAMRepository = phoneRAMRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListPhoneRAMDto>> Handle(GetAllListPhoneRAMQuery request, CancellationToken cancellationToken)
        {
            var phoneRAMs = await _phoneRAMRepository.GetListAsync();

            var mappedPhoneRAMs = _mapper.Map<List<GetAllListPhoneRAMDto>>(phoneRAMs);

            return mappedPhoneRAMs;
        }
    }
}
