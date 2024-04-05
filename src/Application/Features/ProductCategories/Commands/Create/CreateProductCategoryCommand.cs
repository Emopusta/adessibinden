using Application.Features.ProductCategories.Dtos;
using Core.Application.CQRS;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryCommand : ICommandRequest<CreatedProductCategoryResponse>
{
    public string Name { get; set; }

    public CreateProductCategoryCommand(CreateProductCategoryRequestDto createProductCategoryRequestDto)
    {
        Name = createProductCategoryRequestDto.Name;
    }
}
