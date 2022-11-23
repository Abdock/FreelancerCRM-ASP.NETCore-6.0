namespace Persistence.Abstractions;

public abstract class BasePersistenceEntity
{
    public abstract Guid Id { get; set; }
}