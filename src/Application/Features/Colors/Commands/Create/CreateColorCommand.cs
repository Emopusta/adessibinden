using Core.Application.Pipelines.UoW;
using Core.Application.Responses;
using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Create
{

    public class CreateColorCommand : ICommand<CreatedColorResponse>
    {
        public string Name { get; set; }
    }
}
