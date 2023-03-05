using Microsoft.EntityFrameworkCore;

namespace SixPack.Domain.Repositories;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
