using Core.Application.Pipelines;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryCommand : ICommandRequest<CreatedProductCategoryResponse>
{
    public string Name { get; set; }
}
