using Application.Features.CarBrands.Commands.Create;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarChassisTypes.Commands.Create
{
    public class CreateCarChassisTypeCommand : ICommand<CreatedCarChassisTypeResponse>
    {
        public string Name{ get; set; }

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
}
