using Core.Application.Pipelines;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create
{
    public class CreatePhoneBrandCommand : ICommandRequest<CreatedPhoneBrandResponse>
    {
        public string Name { get; set; }

    }
}
