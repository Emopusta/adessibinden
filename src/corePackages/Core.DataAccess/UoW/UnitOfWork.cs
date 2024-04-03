using Core.DataAccess.UoW;
using Core.Logging.Serilog;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UoW;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly IEmopLoggerFactory _emopLoggerFactory;

    public UnitOfWork(TContext dbContext, IEmopLoggerFactory emopLoggerFactory)
    {
        _dbContext = dbContext;
        _emopLoggerFactory = emopLoggerFactory;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        _emopLoggerFactory.ForContext<IUnitOfWork>().Information("Unit of Work called.");

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
