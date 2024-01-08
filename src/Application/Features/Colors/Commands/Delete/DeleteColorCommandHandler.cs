﻿using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IGenericRepository<Color> _colorRepository;

        public DeleteColorCommandHandler(IGenericRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(c => c.Id ==  request.Id);

            var deletedColor = await _colorRepository.DeleteAsync(color);

            DeletedColorResponse result = new()
            {
                Id = deletedColor.Id,
                Name = deletedColor.Name,
            };

            return result;
        }
    }
}
