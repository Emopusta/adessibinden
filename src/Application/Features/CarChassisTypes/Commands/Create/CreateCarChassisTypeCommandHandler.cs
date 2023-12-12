using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.CarChassisTypes.Commands.Create
{
    
        public class CreateCarChassisTypeCommandHandler : IRequestHandler<CreateCarChassisTypeCommand, CreatedCarChassisTypeResponse>
        {
            private readonly IGenericRepository<CarChassisType, Guid>  _repository;

            public CreateCarChassisTypeCommandHandler(IGenericRepository<CarChassisType, Guid> repository)
            {
                _repository = repository;
            }

            public async Task<CreatedCarChassisTypeResponse> Handle(CreateCarChassisTypeCommand request, CancellationToken cancellationToken)
            {
                CarChassisType carChassisType = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name
                };


                CarChassisType addedcarChassisType = await _repository.AddAsync(carChassisType);

                CreatedCarChassisTypeResponse response = new()
                {
                    Id = addedcarChassisType.Id,
                    Name = addedcarChassisType.Name,
                };

                return response;
            }
        
    }
}
