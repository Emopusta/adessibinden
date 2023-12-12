using Core.Application.Pipelines;

namespace Application.Features.CarBrands.Commands.Create
{
    public partial class CreateCarBrandCommand : ICommand<CreatedCarBrandResponse>
    {
        public string Name { get; set; }
    }
}
