namespace Persistence.Abstractions;

public abstract class BasePersistenceEntity
{
    public abstract int Id { get; set; }
    public abstract Guid RowGuid { get; set; }
}