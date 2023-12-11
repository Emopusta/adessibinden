using Application.Services.Repositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Create
{
    public class CreateColorCommand : IRequest<CreatedColorResponse>
    {
        public string Name { get; set; }

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

                await _colorRepository.AddAsync(color);

                CreatedColorResponse response = new()
                {
                    Id = color.Id,
                    Name = color.Name,
                };

                return response;
            }
        }
    }
}
