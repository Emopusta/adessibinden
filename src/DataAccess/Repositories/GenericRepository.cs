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
    public class GenericRepository<TEntity> : EfRepositoryBase<TEntity, AdessibindenContext>, IGenericRepository<TEntity>
        where TEntity : BaseEntity
        
    {
        public GenericRepository(AdessibindenContext context) : base(context)
        {
        }
    }
}
