using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create;

public class CreatePhoneBrandCommandHandler : ICommandRequestHandler<CreatePhoneBrandCommand, CreatedPhoneBrandResponse>
{
    private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
    public CreatePhoneBrandCommandHandler(IGenericRepository<PhoneBrand> phoneBrandRepository)
    {
        _phoneBrandRepository = phoneBrandRepository;
    }

    public async Task<CreatedPhoneBrandResponse> Handle(CreatePhoneBrandCommand request, CancellationToken cancellationToken)
    {

        var phoneBrand = new PhoneBrand()
        {
            Name = request.Name
        };

        var addedphoneBrand = await _phoneBrandRepository.AddAsync(phoneBrand);

        var response = new CreatedPhoneBrandResponse()
        {
            Name = addedphoneBrand.Name,
        };

        return response;
    }
}
