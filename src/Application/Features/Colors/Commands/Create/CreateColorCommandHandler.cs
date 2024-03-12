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
        Color color = new() {
            Name = request.Name
        };

        var addedColor = await _colorRepository.AddAsync(color);

        CreatedColorResponse response = new()
        {
            Name = addedColor.Name,
        };

        return response;  
    }
}
