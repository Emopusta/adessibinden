using Core.Application.Pipelines;
using Core.Application.Requests;
using Core.Application.Responses;

namespace Application.Features.Colors.Queries.GetAll;

public class GetAllColorsQuery : IQueryRequest<PaginateResponse<GetAllColorsListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetAllColorsQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}
