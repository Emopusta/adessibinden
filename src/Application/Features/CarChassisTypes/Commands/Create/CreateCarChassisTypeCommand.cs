using Application.Features.CarBrands.Commands.Create;
using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarChassisTypes.Commands.Create
{
    public partial class CreateCarChassisTypeCommand : ICommand<CreatedCarChassisTypeResponse>
    {
        public string Name{ get; set; }
    }
}
