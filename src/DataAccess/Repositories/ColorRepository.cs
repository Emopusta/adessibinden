using Application.Services.Repositories;
using Core.Persistence.Repositories;
using DataAccess.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ColorRepository : EfRepositoryBase<Color, Guid, AdessibindenContext>, IColorRepository
    {
        public ColorRepository(AdessibindenContext context) : base(context)
        {
        }
    }
}
