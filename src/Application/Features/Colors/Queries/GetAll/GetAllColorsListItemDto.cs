using Core.Application.Dtos;

namespace Application.Features.Colors.Queries.GetAll;

public class GetAllColorsListItemDto :IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}
