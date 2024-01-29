using Core.DataAccess.Repositories;
using DataAccess.Contexts;

namespace DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdessibindenContext _dbContext;

        public UnitOfWork(AdessibindenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();

        }
    }
}
