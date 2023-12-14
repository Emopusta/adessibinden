using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommand : ICommandRequest<DeletedColorResponse>
    {
        public int Id { get; set; }

    }
}
