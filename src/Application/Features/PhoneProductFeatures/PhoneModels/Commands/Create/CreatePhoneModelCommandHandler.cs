using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create;

public class CreatePhoneModelCommandHandler : ICommandRequestHandler<CreatePhoneModelCommand, CreatedPhoneModelResponse>
{
    private readonly IGenericRepository<PhoneModel> _phoneModelRepository;

    public CreatePhoneModelCommandHandler(IGenericRepository<PhoneModel> phoneModelRepository)
    {
        _phoneModelRepository = phoneModelRepository;
    }

    public async Task<CreatedPhoneModelResponse> Handle(CreatePhoneModelCommand request, CancellationToken cancellationToken)
    {
        var phoneModel = new PhoneModel()
        {
            BrandId = request.BrandId,
            Name = request.Name
        };

        var addedPhoneModel = await _phoneModelRepository.AddAsync(phoneModel);

        var response = new CreatedPhoneModelResponse()
        {
            BrandId = addedPhoneModel.BrandId,
            Name = addedPhoneModel.Name
        };
        return response;
    }
}
