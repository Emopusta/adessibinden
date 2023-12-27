using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Pipelines;
using Core.Utilities.Results;

namespace Application.Features.CarBrands.Commands.Create
{
    public partial class CreateCarBrandCommand : ICommandRequest<IDataResult<CreatedCarBrandResponse>>
    {
        public string Name { get; set; }
    }
}
