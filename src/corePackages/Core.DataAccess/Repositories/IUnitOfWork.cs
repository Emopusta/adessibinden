namespace Core.DataAccess.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
    int Save();
}
