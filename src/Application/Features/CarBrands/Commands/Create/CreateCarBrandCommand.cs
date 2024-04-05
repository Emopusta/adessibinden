using Core.Application.CQRS;

namespace Application.Features.CarBrands.Commands.Create;

public partial class CreateCarBrandCommand : ICommandRequest<CreatedCarBrandResponse>
{
    public string Name { get; set; }
}
