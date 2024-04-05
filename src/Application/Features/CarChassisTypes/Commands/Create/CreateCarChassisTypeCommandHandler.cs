using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Domain.Models;

namespace Application.Features.CarChassisTypes.Commands.Create;

public class CreateCarChassisTypeCommandHandler : ICommandRequestHandler<CreateCarChassisTypeCommand, CreatedCarChassisTypeResponse>
{
    private readonly IGenericRepository<CarChassisType>  _repository;
    public CreateCarChassisTypeCommandHandler(IGenericRepository<CarChassisType> repository)
    {
        _repository = repository;
    }

    public async Task<CreatedCarChassisTypeResponse> Handle(CreateCarChassisTypeCommand request, CancellationToken cancellationToken)
    {
        var carChassisType = new CarChassisType()
        {
            Name = request.Name
        };

        var addedcarChassisType = await _repository.AddAsync(carChassisType);

        var response = new CreatedCarChassisTypeResponse()
        {
            Name = addedcarChassisType.Name,
        };

        return response;
    }
}
