namespace WSB.Biblioteka.Core.Generics;

public interface IUnitOfWork : IAsyncDisposable
{
    public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class, IEntity;
    
    public ValueTask SaveChangesAsync(CancellationToken cancellationToken = default);
}