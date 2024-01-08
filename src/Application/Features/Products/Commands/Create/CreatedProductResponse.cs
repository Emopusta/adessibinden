using Core.Application.Responses;

namespace Application.Features.Products.Commands.Create
{
    public class CreatedProductResponse : IResponse
    {
        public int CreatorUserId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}