using Microsoft.EntityFrameworkCore;
using WSB.Biblioteka.Contracts.Exceptions;
using WSB.Biblioteka.Core.Generics;

namespace WSB.Biblioteka.Infrastructure;

public class SqliteAccessingRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet;

    internal SqliteAccessingRepository(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }
    
    public async ValueTask<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public async ValueTask UpdateAsync(TEntity entity, long originVersion, CancellationToken cancellationToken = default)
    {
        var readEntity = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id)
            ?? await _dbSet.FirstAsync(e => e.Id == entity.Id, cancellationToken);
        if (readEntity.Version != originVersion)
            throw new OptimisticConcurrencyException();
        
        _dbSet.Update(entity);
    }

    public ValueTask RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    { 
        _dbSet.Remove(entity);
        
        return ValueTask.CompletedTask;
    }
}