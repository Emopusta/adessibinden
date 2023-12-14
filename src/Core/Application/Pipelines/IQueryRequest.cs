using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines
{
    public interface IQueryRequest<out TResponse> : IRequest<TResponse>
    {
    }
}
