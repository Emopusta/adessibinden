﻿using Application.Features.Colors.Queries.GetById;
using AutoMapper;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Domain.Models;

namespace Application.Features.Colors.Queries.GetAll;

public class GetByIdColorsQueryHandler : IQueryRequestHandler<GetByIdColorQuery, GetByIdColorResponse>
{
    private readonly IGenericRepository<Color> _colorRepository;
    private readonly IMapper _mapper;

    public GetByIdColorsQueryHandler(IGenericRepository<Color> colorRepository, IMapper mapper)
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
