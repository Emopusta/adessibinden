using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList
{
    public class GetAllListPhoneRAMQueryHandler : IQueryRequestHandler<GetAllListPhoneRAMQuery, ListResponse<GetAllListPhoneRAMDto>>
    {
        private readonly IGenericRepository<PhoneRAM> _phoneRAMRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneRAMQueryHandler(IGenericRepository<PhoneRAM> phoneRAMRepository, IMapper mapper)
        {
            _phoneRAMRepository = phoneRAMRepository;
            _mapper = mapper;
        }

        public async Task<ListResponse<GetAllListPhoneRAMDto>> Handle(GetAllListPhoneRAMQuery request, CancellationToken cancellationToken)
        {
            var phoneRAMs = await _phoneRAMRepository.GetListAsync();

            var mappedPhoneRAMs = _mapper.Map<ListResponse<GetAllListPhoneRAMDto>>(phoneRAMs);

            return mappedPhoneRAMs;
        }
    }
}
