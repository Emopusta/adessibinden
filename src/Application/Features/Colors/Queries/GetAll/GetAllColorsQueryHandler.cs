﻿using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Queries.GetAll
{
    public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, GetListResponse<GetAllColorsListItemDto>>
    {
        private readonly IGenericRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public GetAllColorsQueryHandler(IGenericRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        
        public async Task<GetListResponse<GetAllColorsListItemDto>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorRepository.GetPaginateListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<GetListResponse<GetAllColorsListItemDto>>(colors);
            return response;
        }
    }
}
