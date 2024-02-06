using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.Colors.Queries.GetAll;

public class GetAllColorsQueryHandler : IQueryRequestHandler<GetAllColorsQuery, PaginateResponse<GetAllColorsListItemDto>>
{
    private readonly IGenericRepository<Color> _colorRepository;
    private readonly IMapper _mapper;

    public GetAllColorsQueryHandler(IGenericRepository<Color> colorRepository, IMapper mapper)
    {
        _colorRepository = colorRepository;
        _mapper = mapper;
    }
    
    public async Task<PaginateResponse<GetAllColorsListItemDto>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await _colorRepository.GetPaginateListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );

        var response = _mapper.Map<PaginateResponse<GetAllColorsListItemDto>>(colors);
        return response;
    }
}
