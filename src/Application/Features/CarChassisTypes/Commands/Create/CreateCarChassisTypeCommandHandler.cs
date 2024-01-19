using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.CarChassisTypes.Commands.Create
{

    public class CreateCarChassisTypeCommandHandler : ICommandRequestHandler<CreateCarChassisTypeCommand, CreatedCarChassisTypeResponse>
        {
            private readonly IGenericRepository<CarChassisType>  _repository;

            public CreateCarChassisTypeCommandHandler(IGenericRepository<CarChassisType> repository)
            {
                _repository = repository;
            }

            public async Task<CreatedCarChassisTypeResponse> Handle(CreateCarChassisTypeCommand request, CancellationToken cancellationToken)
            {
                CarChassisType carChassisType = new()
                {
                    Name = request.Name
                };


                CarChassisType addedcarChassisType = await _repository.AddAsync(carChassisType);

                CreatedCarChassisTypeResponse response = new()
                {
                    Name = addedcarChassisType.Name,
                };

                return response;
            }
        
    }
}
