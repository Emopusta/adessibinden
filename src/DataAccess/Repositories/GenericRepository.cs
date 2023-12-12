using Core.Application.GenericRepository;
using Core.DataAccess.Entities;
using Core.Persistence.Repositories;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.GenericRepository
{
    public class GenericRepository<TEntity, TEntityId> : EfRepositoryBase<TEntity, TEntityId, AdessibindenContext>, IGenericRepository<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        
    {
        public GenericRepository(AdessibindenContext context) : base(context)
        {
        }
    }
}
