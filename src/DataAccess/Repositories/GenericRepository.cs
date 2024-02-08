using Core.Application.GenericRepository;
using Core.DataAccess.Entities;
using Core.Persistence.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Repositories;

public class GenericRepository<TEntity> : EfRepositoryBase<TEntity, AdessibindenContext>, IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    public GenericRepository(AdessibindenContext context) : base(context) { }
}
