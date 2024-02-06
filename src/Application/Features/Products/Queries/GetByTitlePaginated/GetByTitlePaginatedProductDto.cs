using Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetByTitlePaginated;

public class GetByTitlePaginatedProductDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}