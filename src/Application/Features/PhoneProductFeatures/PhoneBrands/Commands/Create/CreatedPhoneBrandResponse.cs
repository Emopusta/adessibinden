using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneBrands.Commands.Create
{
    public class CreatedPhoneBrandResponse : IResponse
    {
        public string Name { get; set; }
    }
}