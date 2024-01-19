using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList
{
    public class GetAllListPhoneModelQueryHandler : IQueryRequestHandler<GetAllListPhoneModelQuery, ListResponse<GetAllListPhoneModelDto>>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneModelQueryHandler(IGenericRepository<PhoneModel> phoneModelRepository, IMapper mapper)
        {
            _phoneModelRepository = phoneModelRepository;
            _mapper = mapper;
        }

        public async Task<ListResponse<GetAllListPhoneModelDto>> Handle(GetAllListPhoneModelQuery request, CancellationToken cancellationToken)
        {
            var phoneModels = await _phoneModelRepository.GetListAsync(include: i => i.Include(p => p.Brand));

            var mappedphoneModels = _mapper.Map<ListResponse<GetAllListPhoneModelDto>>(phoneModels);

            return mappedphoneModels;
        }
    }
}
