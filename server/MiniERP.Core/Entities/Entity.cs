namespace MiniERP.Core.Entities;

public interface IEntity
{
    int Id { get; set; }
}

public abstract class Entity : IEntity
{
    public int Id { get; set; }
}