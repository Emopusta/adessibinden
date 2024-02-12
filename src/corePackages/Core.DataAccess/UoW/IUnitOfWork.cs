namespace Core.DataAccess.UoW;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
    int Save();
}
