using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Dtos;

public class CreateProductCategoryRequestDto : IRequestDto
{
    public string Name { get; set; }
}
