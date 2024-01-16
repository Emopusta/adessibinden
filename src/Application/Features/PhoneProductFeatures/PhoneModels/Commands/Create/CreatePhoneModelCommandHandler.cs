using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create
{
    public class CreatePhoneModelCommandHandler : IRequestHandler<CreatePhoneModelCommand, CreatedPhoneModelResponse>
    {
        private readonly IGenericRepository<PhoneModel> _phoneModelRepository;

        public CreatePhoneModelCommandHandler(IGenericRepository<PhoneModel> phoneModelRepository)
        {
            _phoneModelRepository = phoneModelRepository;
        }

        public async Task<CreatedPhoneModelResponse> Handle(CreatePhoneModelCommand request, CancellationToken cancellationToken)
        {
            PhoneModel phoneModel = new()
            {
                BrandId = request.BrandId,
                Name = request.Name
            };

            PhoneModel addedPhoneModel = await _phoneModelRepository.AddAsync(phoneModel);

            CreatedPhoneModelResponse response = new()
            {
                BrandId = addedPhoneModel.BrandId,
                Name = addedPhoneModel.Name
            };

            return response;
        }
    }
}
