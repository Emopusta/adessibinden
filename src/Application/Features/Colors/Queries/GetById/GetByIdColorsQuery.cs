using Application.Features.Colors.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Colors.Queries.GetAll
{
    public class GetByIdColorQuery : IRequest<GetByIdColorResponse>
    {
        public int Id { get; set; }


    }

}
