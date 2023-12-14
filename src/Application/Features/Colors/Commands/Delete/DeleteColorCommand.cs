using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommand : ICommand<DeletedColorResponse>
    {
        public int Id { get; set; }

    }
}
