using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId
{
    public class GetByBrandIdPhoneModelQuery : IQueryRequest<List<GetByBrandIdPhoneModelDto>>
    {
        public int BrandId { get; set; }
    }
}
