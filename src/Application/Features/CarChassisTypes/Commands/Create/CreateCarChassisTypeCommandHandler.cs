﻿using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.CarChassisTypes.Commands.Create
{

    public class CreateCarChassisTypeCommandHandler : IRequestHandler<CreateCarChassisTypeCommand, CreatedCarChassisTypeResponse>
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
