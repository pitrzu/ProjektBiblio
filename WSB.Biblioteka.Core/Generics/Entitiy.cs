namespace WSB.Biblioteka.Core.Generics;

public abstract class Entity(Guid id, long version) : IEntity
{
    public Guid Id { get; } = id;
    public long Version { get; } = version;

    public bool Equals(IEntity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.GetType() != GetType()) return false;

        return Id.Equals(other.Id);
    }

    public bool Equals(Entity? other) => Equals((IEntity?)other);
    public override bool Equals(object? obj) => Equals(obj as IEntity);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);
    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);
}
