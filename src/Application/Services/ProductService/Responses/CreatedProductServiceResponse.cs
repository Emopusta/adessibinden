using Core.Application.Responses;

namespace Application.Services.ProductService.Responses
{
    public class CreatedProductServiceResponse : IResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}