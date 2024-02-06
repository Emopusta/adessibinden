using Core.Application.Dtos;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreatorUserId { get; set; }
    public int ProductCategoryId { get; set; }
}
