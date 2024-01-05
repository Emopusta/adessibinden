using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetById
{
    public class GetByIdUserProfileQuery : IQueryRequest<GetUserProfileResponse>
    {
        public int UserId { get; set; }
    }
}
