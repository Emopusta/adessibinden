using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarChassisTypes.Commands.Create
{
    public class CreatedCarChassisTypeResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
