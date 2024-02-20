using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;

public class GetAllPaginatedProductDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}