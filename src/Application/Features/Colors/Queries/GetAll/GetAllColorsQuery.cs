using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Colors.Queries.GetAll
{
    public class GetAllColorsQuery : IRequest<GetListResponse<GetAllColorsListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        
    }

}
