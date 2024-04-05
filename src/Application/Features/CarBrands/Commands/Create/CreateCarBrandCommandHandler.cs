using Core.Application.CQRS;
using Core.Application.GenericRepository;
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
        var carBrand = new CarBrand()
        {
            Name = request.Name
        };

        var addedCarBrand = await _repository.AddAsync(carBrand);

        var result = new CreatedCarBrandResponse()
        {
            Name = addedCarBrand.Name,
        };

        return result;
    }
}
