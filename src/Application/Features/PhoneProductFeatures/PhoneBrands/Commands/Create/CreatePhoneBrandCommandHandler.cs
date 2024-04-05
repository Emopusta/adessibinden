using Core.Application.CQRS;
using Core.Application.GenericRepository;
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

        PhoneBrand phoneBrand = new()
        {
            Name = request.Name
        };

        var addedphoneBrand = await _phoneBrandRepository.AddAsync(phoneBrand);

        CreatedPhoneBrandResponse response = new()
        {
            Name = addedphoneBrand.Name,
        };

        return response;
    }
}
