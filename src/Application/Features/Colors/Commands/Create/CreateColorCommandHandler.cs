using Application.Services.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Features.Colors.Commands.Create
{

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
        {
            private readonly IColorRepository _colorRepository;

            public CreateColorCommandHandler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                Color color = new() { 
                    Id = Guid.NewGuid(),
                    Name = request.Name
                };

                Color addedColor = await _colorRepository.AddAsync(color);

                CreatedColorResponse response = new()
                {
                    Id = addedColor.Id,
                    Name = addedColor.Name,
                };

                return response;
            
        }
    }
}
