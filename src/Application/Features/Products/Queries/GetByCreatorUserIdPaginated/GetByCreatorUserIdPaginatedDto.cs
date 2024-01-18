using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetByCreatorUserIdPaginated
{
    public class GetByCreatorUserIdPaginatedDto : IResponse
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
    }
}