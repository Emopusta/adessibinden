using Core.DataAccess.UoW;
using Core.Logging.Serilog;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UoW;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly IEmopLogger _emopLogger;

    public UnitOfWork(TContext dbContext, IEmopLoggerFactory emopLoggerFactory)
    {
        _dbContext = dbContext;
        _emopLogger = emopLoggerFactory.ForContext<IUnitOfWork>();
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        _emopLogger.Information("Unit of Work called.");

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
