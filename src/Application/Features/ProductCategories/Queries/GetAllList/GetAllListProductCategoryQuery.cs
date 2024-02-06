using Core.Application.Pipelines;
using Core.Application.Responses;

namespace Application.Features.ProductCategories.Queries.GetAllList;
public class GetAllListProductCategoryQuery : IQueryRequest<ListResponse<GetAllListProductCategoryDto>>
{
}
