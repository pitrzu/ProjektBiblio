using WSB.Biblioteka.Contracts.Exceptions;
using WSB.Biblioteka.Core.Generics;

namespace WSB.Biblioteka.Core.Extensions;

public static class RepositoryExtensions
{
    public static async ValueTask<TEntity> GetAsync<TEntity>(this IRepository<TEntity> repository, Guid id, CancellationToken cancellationToken = default)
        where TEntity : IEntity => await repository.FindAsync(id, cancellationToken) ?? throw EntityNotFoundException.Of<TEntity>(id);

    public static async Task<IReadOnlyCollection<TEntity>> FindManyAsync<TEntity>(this IRepository<TEntity> repository, IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        where TEntity : class, IEntity => (await ids.ProjectAsync(repository.FindAsync, cancellationToken)).SkipNulls().AsReadOnlyCollection();

    public static async Task<IReadOnlyCollection<TEntity>> GetManyAsync<TEntity>(this IRepository<TEntity> repository, IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        where TEntity : class, IEntity
    {
        var idsEnumerated = ids.AsList();
        var entities = await repository.FindManyAsync(idsEnumerated, cancellationToken);
        if (entities.Count == idsEnumerated.Count)
            return entities;

        var foundIds = entities.Project(x => x.Id);
        var notFoundIds = idsEnumerated
            .Where(id => !foundIds.Contains(id));
        
        throw new AggregateException("Following ids were not found!", notFoundIds.Select(EntityNotFoundException.Of<TEntity>));
    }

    public static async ValueTask AddManyAsync<TEntity>(this IRepository<TEntity> repository, IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        where TEntity : IEntity
    {
        foreach (var entity in entities)
            await repository.AddAsync(entity, cancellationToken);
    }

    public static async ValueTask RemoveAsync<TEntity>(this IRepository<TEntity> repository, Guid id, CancellationToken cancellationToken = default)
        where TEntity : IEntity
    {
        var entity = await repository.GetAsync(id, cancellationToken);

        await repository.RemoveAsync(entity, cancellationToken);
    }
}