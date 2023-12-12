using Core.DataAccess.Entities;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.GenericRepository
{
    public interface IGenericRepository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>, IAsyncRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
    {
    }
}
