using Core.Application.Responses;

namespace Application.Services.ProductService.Responses
{
    public class CreatedProductServiceResponse : IResponse
    {
        public int Id { get; set; }
        public int CreatorUserId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}