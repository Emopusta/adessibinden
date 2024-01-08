using Core.Application.Responses;

namespace Application.Features.PhoneProductFeatures.PhoneModels.Commands.Create
{
    public class CreatedPhoneModelResponse : IResponse
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}