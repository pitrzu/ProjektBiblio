namespace WSB.Biblioteka.Core.Generics;

public interface IRepository<TEntity> where TEntity : IEntity
{
    public ValueTask<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    public ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    public ValueTask UpdateAsync(TEntity entity, long originVersion, CancellationToken cancellationToken = default);
    public ValueTask RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
}