using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Dtos;

public class GetAllListProductCategoryDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}