using Core.Persistence.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IColorRepository : IAsyncRepository<Color, Guid>, IRepository<Color, Guid>
    {
    }
}
