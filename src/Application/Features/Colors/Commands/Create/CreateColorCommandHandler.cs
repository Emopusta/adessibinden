using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.Colors.Commands.Create;
public class CreateColorCommandHandler : ICommandRequestHandler<CreateColorCommand, CreatedColorResponse>
{
    private readonly IGenericRepository<Color> _colorRepository;

    public CreateColorCommandHandler(IGenericRepository<Color> colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var color = new Color() {
            Name = request.Name
        };

        var addedColor = await _colorRepository.AddAsync(color);

        var response = new CreatedColorResponse()
        {
            Name = addedColor.Name,
        };

        return response;  
    }
}
