namespace WSB.Biblioteka.Core.Generics;

public interface IEntity : IEquatable<IEntity>
{
    public Guid Id { get; }
    public long Version { get; }
}