using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;

namespace Core.Application.GenericRepository
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
