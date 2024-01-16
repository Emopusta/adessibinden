using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetAllList
{
    public class GetAllListPhoneModelQueryHandler : IRequestHandler<GetAllListPhoneModelQuery, List<GetAllListPhoneModelDto>>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;
        private readonly IMapper _mapper;

        public GetAllListPhoneModelQueryHandler(IGenericRepository<PhoneModel> phoneModelRepository, IMapper mapper)
        {
            _phoneModelRepository = phoneModelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListPhoneModelDto>> Handle(GetAllListPhoneModelQuery request, CancellationToken cancellationToken)
        {
            var phoneModels = await _phoneModelRepository.GetListAsync(include: i => i.Include(p => p.Brand));

            var mappedphoneModels = _mapper.Map<List<GetAllListPhoneModelDto>>(phoneModels);

            return mappedphoneModels;
        }
    }
}
