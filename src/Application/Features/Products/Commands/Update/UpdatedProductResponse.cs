using Core.Application.Responses;

namespace Application.Features.Products.Commands.Update
{
    public class UpdatedProductResponse : IResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
