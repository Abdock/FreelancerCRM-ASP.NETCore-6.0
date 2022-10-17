namespace Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    private bool Equals(BaseEntity other)
    {
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((BaseEntity) obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}