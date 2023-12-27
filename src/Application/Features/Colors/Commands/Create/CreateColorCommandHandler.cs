using Application.Features.Colors.Rules;
using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Core.Utilities.Results;
using Domain.Models;
using MediatR;

namespace Application.Features.Colors.Commands.Create
{

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, IDataResult<CreatedColorResponse>>
        {
        private readonly IGenericRepository<Color> _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;

        public CreateColorCommandHandler(IGenericRepository<Color> colorRepository, ColorBusinessRules colorBusinessRules)
        {
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<IDataResult<CreatedColorResponse>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            await _colorBusinessRules.ColorNameCannotDuplicate(request.Name);
            
            Color color = new() {
                Name = request.Name
            };

            Color addedColor = await _colorRepository.AddAsync(color);

            CreatedColorResponse response = new()
            {
                Name = addedColor.Name,
            };

            return new SuccessDataResult<CreatedColorResponse>(response);
            
        }
    }
}
