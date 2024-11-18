namespace WSB.Biblioteka.Contracts.Exceptions;

public class EntityNotFoundException : Exception
{
    private EntityNotFoundException(string message) : base(message){}
    
    public static EntityNotFoundException Of<TEntity>(Guid id) =>
        new($"Entity {typeof(TEntity).Name} with id {id} was not found.");
}