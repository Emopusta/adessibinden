using Application.Features.PhoneProductFeatures.PhoneBrands.Rules;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create
{
    public class CreatePhoneBrandCommandHandler : IRequestHandler<CreatePhoneBrandCommand, CreatedPhoneBrandResponse>
    {
        private readonly IGenericRepository<PhoneBrand> _phoneBrandRepository;
        private readonly PhoneBrandBusinessRules _phoneBrandBusinessRules;

        public CreatePhoneBrandCommandHandler(IGenericRepository<PhoneBrand> phoneBrandRepository, PhoneBrandBusinessRules phoneBrandBusinessRules)
        {
            _phoneBrandRepository = phoneBrandRepository;
            _phoneBrandBusinessRules = phoneBrandBusinessRules;
        }

        public async Task<CreatedPhoneBrandResponse> Handle(CreatePhoneBrandCommand request, CancellationToken cancellationToken)
        {
            await _phoneBrandBusinessRules.PhoneBrandNameCannotDuplicate(request.Name);

            PhoneBrand phoneBrand = new()
            {
                Name = request.Name
            };

            PhoneBrand addedphoneBrand = await _phoneBrandRepository.AddAsync(phoneBrand);

            CreatedPhoneBrandResponse response = new()
            {
                Name = addedphoneBrand.Name,
            };

            return response;
        }
    }
}
