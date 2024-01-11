using Core.Application.Pipelines;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails
{
    public class GetByIdDetailsPhoneProductQuery : IQueryRequest<GetByIdDetailsPhoneProductResponse>
    {
        public int PhoneProductId { get; set; }
    }
}
