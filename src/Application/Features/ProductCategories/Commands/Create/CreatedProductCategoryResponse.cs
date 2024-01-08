using Core.Application.Responses;

namespace Application.Features.ProductCategories.Commands.Create
{
    public class CreatedProductCategoryResponse : IResponse
    {
        public string Name { get; set; }

    }
}