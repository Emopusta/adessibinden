using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.CarBrands.Commands.Create
{

    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand, CreatedCarBrandResponse>
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
}
