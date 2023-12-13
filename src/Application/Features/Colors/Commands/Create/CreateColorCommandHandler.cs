using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Features.Colors.Commands.Create
{

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
        {
            private readonly IGenericRepository<Color, int> _colorRepository;
        

        public CreateColorCommandHandler(IGenericRepository<Color, int> colorRepository, IUnitOfWork unitOfWork)
        {
            _colorRepository = colorRepository;  
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
                    
            Color color = new() {
                Name = request.Name
            };

                    
            Color addedColor = await _colorRepository.AddAsync(color);
            
            CreatedColorResponse response = new()
            {
                Name = addedColor.Name,
            };

            return response;
            
        }
    }
}
