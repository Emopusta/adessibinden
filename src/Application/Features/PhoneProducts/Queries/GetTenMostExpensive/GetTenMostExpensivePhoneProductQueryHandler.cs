using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.PhoneProducts.Queries.GetTenMostExpensive;

public class GetTenMostExpensivePhoneProductQueryHandler : IQueryRequestHandler<GetTenMostExpensivePhoneProductQuery, ListResponse<PhoneProduct>>
{
    private readonly IPhoneProductRepository _phoneProductRepository;
    private readonly IMapper _mapper;

    public GetTenMostExpensivePhoneProductQueryHandler(IPhoneProductRepository phoneProductRepository, IMapper mapper)
    {
        _phoneProductRepository = phoneProductRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<PhoneProduct>> Handle(GetTenMostExpensivePhoneProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _phoneProductRepository.GetTenMostExpensive();

        var response = new ListResponse<PhoneProduct>();
        foreach (var phoneProduct in result) {
            response.Items.Add(phoneProduct);
        }

        return response;
    }
}
