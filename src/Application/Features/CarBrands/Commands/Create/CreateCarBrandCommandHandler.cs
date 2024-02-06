using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.CarBrands.Commands.Create;

public class CreateCarBrandCommandHandler : ICommandRequestHandler<CreateCarBrandCommand, CreatedCarBrandResponse>
{
    private readonly IGenericRepository<CarBrand> _repository;
    public CreateCarBrandCommandHandler(IGenericRepository<CarBrand> repository)
    {
        _repository = repository;
    }

    public async Task<CreatedCarBrandResponse> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
    {
        CarBrand carBrand = new()
        {
            Name = request.Name
        };

        CarBrand addedCarBrand = await _repository.AddAsync(carBrand);

        CreatedCarBrandResponse result = new()
        {
            Name = addedCarBrand.Name,
        };

        return result;
    }
}
