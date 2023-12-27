using Core.Application.GenericRepository;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;

namespace Application.Features.CarBrands.Commands.Create
{

    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand, IDataResult<CreatedCarBrandResponse>>
        {
            private readonly IGenericRepository<CarBrand> _repository;

            public CreateCarBrandCommandHandler(IGenericRepository<CarBrand> repository)
            {
                _repository = repository;
            }

            public async Task<IDataResult<CreatedCarBrandResponse>> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
            {
                CarBrand carBrand = new()
                {
                    Name = request.Name
                };


                CarBrand addedCarBrand = await _repository.AddAsync(carBrand);

                CreatedCarBrandResponse response = new()
                {
                    Name = addedCarBrand.Name,
                };

                return new SuccessDataResult<CreatedCarBrandResponse>(response, "Car brand created.");
            }
        
    }
}
