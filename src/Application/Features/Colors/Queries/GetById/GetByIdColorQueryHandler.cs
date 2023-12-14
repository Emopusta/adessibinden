using Application.Features.Colors.Queries.GetById;
using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Models;
using MediatR;

namespace Application.Features.Colors.Queries.GetAll
{
    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, GetByIdColorResponse>
    {
        private readonly IGenericRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public GetByIdColorQueryHandler(IGenericRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdColorResponse> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
        {
            Color? colors = await _colorRepository.GetAsync(
                predicate: p => p.Id == request.Id,
                cancellationToken: cancellationToken
                );

            GetByIdColorResponse response = _mapper.Map<GetByIdColorResponse>(colors);
            return response;
        }
    }
}
