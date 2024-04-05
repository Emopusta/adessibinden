using Core.Application.CQRS;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.PhoneProducts.Queries.GetTenMostExpensive;

public class GetTenMostExpensivePhoneProductQuery : IQueryRequest<ListResponse<PhoneProduct>>
{
}
