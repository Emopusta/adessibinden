using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.CarBrands.Commands.Create
{

    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand, CreatedCarBrandResponse>
        {
            private readonly IGenericRepository<CarBrand, Guid> _repository;

            public CreateCarBrandCommandHandler(IGenericRepository<CarBrand, Guid> repository)
            {
                _repository = repository;
            }

            public async Task<CreatedCarBrandResponse> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
            {
                CarBrand carBrand = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name
                };


                CarBrand addedCarBrand = await _repository.AddAsync(carBrand);

                CreatedCarBrandResponse response = new()
                {
                    Id = addedCarBrand.Id,
                    Name = addedCarBrand.Name,
                };

                return response;
            }
        
    }
}
