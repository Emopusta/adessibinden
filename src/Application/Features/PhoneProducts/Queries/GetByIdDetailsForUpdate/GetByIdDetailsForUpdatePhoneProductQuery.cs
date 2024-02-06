using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;

public class GetByIdDetailsForUpdatePhoneProductQuery : IQueryRequest<GetByIdDetailsForUpdatePhoneProductResponse>
{
    public int ProductId { get; set; }
}
