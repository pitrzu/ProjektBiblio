using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using WSB.Biblioteka.Core.Generics;

namespace WSB.Biblioteka.Infrastructure;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    private bool _disposed = false;

    private readonly IDictionary<Type, object> _repositories = new ConcurrentDictionary<Type, object>();

    public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class, IEntity
    {
        if (context.Database.CurrentTransaction is null)
            context.Database.BeginTransaction();

        if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            return (IRepository<TEntity>)repository;

        var repo = new SqliteAccessingRepository<TEntity>(context);
        _repositories[typeof(TEntity)] = repo;

        return repo;
    }

    public async ValueTask SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (context.Database.CurrentTransaction is null)
            return;

        await context.Database.CurrentTransaction.CommitAsync(cancellationToken);
        await context.Database.CurrentTransaction.DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (context.Database.CurrentTransaction is not null)
            {
                await context.Database.CurrentTransaction.RollbackAsync();
            }

            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }
}
