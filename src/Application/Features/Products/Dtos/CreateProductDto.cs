using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;

public class CreateProductDto : IDto
{
    public int CreatorUserId { get; set; }
    public int ProductCategoryId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}
