using Application.Features.Colors.Dtos;
using Application.Features.Colors.Queries.GetById;
using Core.Application.Pipelines;

namespace Application.Features.Colors.Queries.GetAll;

public class GetByIdColorQuery : IQueryRequest<GetByIdColorResponse>
{
    public int Id { get; set; }
    public GetByIdColorQuery(GetByIdColorsRequestDto getByIdColorsRequestDto)
    {
        Id = getByIdColorsRequestDto.Id;
    }
}
