using Core.Application.Pipelines;
using Core.Application.Pipelines.Authorization;
using Core.Security.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommand : ICommandRequest<DeletedColorResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { GeneralOperationClaims.Admin };
    }
}
