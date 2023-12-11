using Application.Services.Repositories;
using Core.DataAccess.Repositories;
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
            private readonly IUnitOfWork _unitOfWork;

            public CreateColorCommandHandler(IColorRepository colorRepository, IUnitOfWork unitOfWork)
            {
                _colorRepository = colorRepository;
                _unitOfWork = unitOfWork;
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

                await _unitOfWork.Save();
                return response;
            }
        }
    }
}
