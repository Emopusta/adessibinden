using Core.Application.Pipelines;
using Core.Utilities.Results;

namespace Application.Features.Colors.Commands.Create
{

    public class CreateColorCommand : ICommandRequest<CreatedColorResponse>
    {
        public string Name { get; set; }
        
        
    }
}
