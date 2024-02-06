using Core.Application.Responses;

namespace Application.Features.CarBrands.Commands.Create;

public class CreatedCarBrandResponse : IResponse
{
    public string Name { get; set; }
}
