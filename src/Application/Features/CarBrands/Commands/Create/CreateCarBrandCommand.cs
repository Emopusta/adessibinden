using Core.Application.Pipelines;

namespace Application.Features.CarBrands.Commands.Create
{
    public partial class CreateCarBrandCommand : ICommandRequest<CreatedCarBrandResponse>
    {
        public string Name { get; set; }
    }
}
